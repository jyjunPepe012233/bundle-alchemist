using UnityEditor;
using UnityEngine;

namespace Core.Editor.InterfaceRef
{

	[CustomPropertyDrawer(typeof(Core.Type.InterfaceRef<>))]
	public class InterfaceRefDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var targetProp = property.FindPropertyRelative("target");
			var interfaceType = ExtractInterfaceType(fieldInfo.FieldType);
			DrawInterfaceField(position, targetProp, label, interfaceType);
		}

		internal static void DrawInterfaceField(Rect position, SerializedProperty targetProp, GUIContent label,
			System.Type interfaceType)
		{
			var old = targetProp.objectReferenceValue;

			var obj = EditorGUI.ObjectField(
				position,
				label,
				old,
				typeof(UnityEngine.Object),
				true
			);

			if (obj == null)
			{
				targetProp.objectReferenceValue = null;
				return;
			}

			if (interfaceType.IsAssignableFrom(obj.GetType()))
			{
				targetProp.objectReferenceValue = obj;
				return;
			}

			if (obj is GameObject go && go.TryGetComponent(interfaceType, out Component comp))
			{
				targetProp.objectReferenceValue = comp;
				return;
			}

			Debug.LogWarning($"{interfaceType.Name}를 구현한 클래스의 객체를 할당해야 합니다.");
			targetProp.objectReferenceValue = old;
		}

		internal static System.Type ExtractInterfaceType(System.Type fieldType)
		{
			if (fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(Core.Type.InterfaceRef<>))
				return fieldType.GetGenericArguments()[0];

			if (fieldType.IsArray)
				return fieldType.GetElementType().GetGenericArguments()[0];

			if (fieldType.IsGenericType)
				return fieldType.GetGenericArguments()[0].GetGenericArguments()[0];

			return fieldType.GetGenericArguments()[0];
		}
	}

	[CustomPropertyDrawer(typeof(Core.Type.InterfaceRefs<>))]
	public class InterfaceRefsDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var targetsProp = property.FindPropertyRelative("targets");
			var interfaceType = fieldInfo.FieldType.GetGenericArguments()[0];

			targetsProp.isExpanded = EditorGUI.Foldout(
				new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight),
				targetsProp.isExpanded, label, true);

			if (!targetsProp.isExpanded) return;

			EditorGUI.indentLevel++;
			float y = position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

			// Size 필드
			var sizeRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
			var newSize = EditorGUI.DelayedIntField(sizeRect, "Size", targetsProp.arraySize);
			if (newSize != targetsProp.arraySize)
				targetsProp.arraySize = newSize;

			y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

			// 각 요소를 인터페이스 검증 필드로 그림
			for (int i = 0; i < targetsProp.arraySize; i++)
			{
				var elementRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
				var elementProp = targetsProp.GetArrayElementAtIndex(i);
				InterfaceRefDrawer.DrawInterfaceField(elementRect, elementProp, new GUIContent($"Element {i}"),
					interfaceType);
				y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
			}

			EditorGUI.indentLevel--;
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			var targetsProp = property.FindPropertyRelative("targets");

			if (!targetsProp.isExpanded)
				return EditorGUIUtility.singleLineHeight;

			// foldout + size + elements
			int lines = 2 + targetsProp.arraySize;
			return lines * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
		}
	}

}
