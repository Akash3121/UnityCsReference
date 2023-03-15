// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

/******************************************************************************/
//
//                             DO NOT MODIFY
//          This file has been generated by the UIElementsGenerator tool
//              See ResolvedStyleInterfaceCsGenerator class for details
//
/******************************************************************************/
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
    /// <summary>
    /// Style values after layout pass.
    /// </summary>
    public partial interface IResolvedStyle
    {
        /// <summary>
        /// Alignment of the whole area of children on the cross axis if they span over multiple lines in this container.
        /// </summary>
        Align alignContent { get; }
        /// <summary>
        /// Alignment of children on the cross axis of this container.
        /// </summary>
        Align alignItems { get; }
        /// <summary>
        /// Similar to align-items, but only for this specific element.
        /// </summary>
        Align alignSelf { get; }
        /// <summary>
        /// Background color to paint in the element's box.
        /// </summary>
        Color backgroundColor { get; }
        /// <summary>
        /// Background image to paint in the element's box.
        /// </summary>
        Background backgroundImage { get; }
        /// <summary>
        /// Background image x position value.
        /// </summary>
        BackgroundPosition backgroundPositionX { get; }
        /// <summary>
        /// Background image y position value.
        /// </summary>
        BackgroundPosition backgroundPositionY { get; }
        /// <summary>
        /// Background image repeat value.
        /// </summary>
        BackgroundRepeat backgroundRepeat { get; }
        /// <summary>
        /// Background image size value.
        /// </summary>
        BackgroundSize backgroundSize { get; }
        /// <summary>
        /// Color of the element's bottom border.
        /// </summary>
        Color borderBottomColor { get; }
        /// <summary>
        /// The radius of the bottom-left corner when a rounded rectangle is drawn in the element's box.
        /// </summary>
        float borderBottomLeftRadius { get; }
        /// <summary>
        /// The radius of the bottom-right corner when a rounded rectangle is drawn in the element's box.
        /// </summary>
        float borderBottomRightRadius { get; }
        /// <summary>
        /// Space reserved for the bottom edge of the border during the layout phase.
        /// </summary>
        float borderBottomWidth { get; }
        /// <summary>
        /// Color of the element's left border.
        /// </summary>
        Color borderLeftColor { get; }
        /// <summary>
        /// Space reserved for the left edge of the border during the layout phase.
        /// </summary>
        float borderLeftWidth { get; }
        /// <summary>
        /// Color of the element's right border.
        /// </summary>
        Color borderRightColor { get; }
        /// <summary>
        /// Space reserved for the right edge of the border during the layout phase.
        /// </summary>
        float borderRightWidth { get; }
        /// <summary>
        /// Color of the element's top border.
        /// </summary>
        Color borderTopColor { get; }
        /// <summary>
        /// The radius of the top-left corner when a rounded rectangle is drawn in the element's box.
        /// </summary>
        float borderTopLeftRadius { get; }
        /// <summary>
        /// The radius of the top-right corner when a rounded rectangle is drawn in the element's box.
        /// </summary>
        float borderTopRightRadius { get; }
        /// <summary>
        /// Space reserved for the top edge of the border during the layout phase.
        /// </summary>
        float borderTopWidth { get; }
        /// <summary>
        /// Bottom distance from the element's box during layout.
        /// </summary>
        float bottom { get; }
        /// <summary>
        /// Color to use when drawing the text of an element.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        Color color { get; }
        /// <summary>
        /// Defines how an element is displayed in the layout.
        /// </summary>
        /// <remarks>
        /// Unlike the visibility property, this property affects the layout of the element.
        /// This is a convenient way to hide an element without removing it from the hierarchy (when using the <see cref="DisplayStyle.None"/>).
        /// </remarks>
        DisplayStyle display { get; }
        /// <summary>
        /// Initial main size of a flex item, on the main flex axis. The final layout might be smaller or larger, according to the flex shrinking and growing determined by the other flex properties.
        /// </summary>
        StyleFloat flexBasis { get; }
        /// <summary>
        /// Direction of the main axis to layout children in a container.
        /// </summary>
        FlexDirection flexDirection { get; }
        /// <summary>
        /// Specifies how the item will shrink relative to the rest of the flexible items inside the same container.
        /// </summary>
        float flexGrow { get; }
        /// <summary>
        /// Specifies how the item will shrink relative to the rest of the flexible items inside the same container.
        /// </summary>
        float flexShrink { get; }
        /// <summary>
        /// Placement of children over multiple lines if not enough space is available in this container.
        /// </summary>
        Wrap flexWrap { get; }
        /// <summary>
        /// Font size to draw the element's text.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        float fontSize { get; }
        /// <summary>
        /// Fixed height of an element for the layout.
        /// </summary>
        float height { get; }
        /// <summary>
        /// Justification of children on the main axis of this container.
        /// </summary>
        Justify justifyContent { get; }
        /// <summary>
        /// Left distance from the element's box during layout.
        /// </summary>
        float left { get; }
        /// <summary>
        /// Increases or decreases the space between characters.
        /// </summary>
        float letterSpacing { get; }
        /// <summary>
        /// Space reserved for the bottom edge of the margin during the layout phase.
        /// </summary>
        float marginBottom { get; }
        /// <summary>
        /// Space reserved for the left edge of the margin during the layout phase.
        /// </summary>
        float marginLeft { get; }
        /// <summary>
        /// Space reserved for the right edge of the margin during the layout phase.
        /// </summary>
        float marginRight { get; }
        /// <summary>
        /// Space reserved for the top edge of the margin during the layout phase.
        /// </summary>
        float marginTop { get; }
        /// <summary>
        /// Maximum height for an element, when it is flexible or measures its own size.
        /// </summary>
        StyleFloat maxHeight { get; }
        /// <summary>
        /// Maximum width for an element, when it is flexible or measures its own size.
        /// </summary>
        StyleFloat maxWidth { get; }
        /// <summary>
        /// Minimum height for an element, when it is flexible or measures its own size.
        /// </summary>
        StyleFloat minHeight { get; }
        /// <summary>
        /// Minimum width for an element, when it is flexible or measures its own size.
        /// </summary>
        StyleFloat minWidth { get; }
        /// <summary>
        /// Specifies the transparency of an element and of its children.
        /// </summary>
        /// <remarks>
        /// The opacity can be between 0.0 and 1.0. The lower value, the more transparent.
        /// </remarks>
        float opacity { get; }
        /// <summary>
        /// Space reserved for the bottom edge of the padding during the layout phase.
        /// </summary>
        float paddingBottom { get; }
        /// <summary>
        /// Space reserved for the left edge of the padding during the layout phase.
        /// </summary>
        float paddingLeft { get; }
        /// <summary>
        /// Space reserved for the right edge of the padding during the layout phase.
        /// </summary>
        float paddingRight { get; }
        /// <summary>
        /// Space reserved for the top edge of the padding during the layout phase.
        /// </summary>
        float paddingTop { get; }
        /// <summary>
        /// Element's positioning in its parent container.
        /// </summary>
        /// <remarks>
        /// This property is used in conjunction with left, top, right and bottom properties.
        /// </remarks>
        Position position { get; }
        /// <summary>
        /// Right distance from the element's box during layout.
        /// </summary>
        float right { get; }
        /// <summary>
        /// A rotation transformation.
        /// </summary>
        Rotate rotate { get; }
        /// <summary>
        /// A scaling transformation.
        /// </summary>
        Scale scale { get; }
        /// <summary>
        /// The element's text overflow mode.
        /// </summary>
        TextOverflow textOverflow { get; }
        /// <summary>
        /// Top distance from the element's box during layout.
        /// </summary>
        float top { get; }
        /// <summary>
        /// The transformation origin is the point around which a transformation is applied.
        /// </summary>
        Vector3 transformOrigin { get; }
        /// <summary>
        /// Duration to wait before starting a property's transition effect when its value changes.
        /// </summary>
        IEnumerable<TimeValue> transitionDelay { get; }
        /// <summary>
        /// Time a transition animation should take to complete.
        /// </summary>
        IEnumerable<TimeValue> transitionDuration { get; }
        /// <summary>
        /// Properties to which a transition effect should be applied.
        /// </summary>
        IEnumerable<StylePropertyName> transitionProperty { get; }
        /// <summary>
        /// Determines how intermediate values are calculated for properties modified by a transition effect.
        /// </summary>
        IEnumerable<EasingFunction> transitionTimingFunction { get; }
        /// <summary>
        /// A translate transformation.
        /// </summary>
        Vector3 translate { get; }
        /// <summary>
        /// Tinting color for the element's backgroundImage.
        /// </summary>
        Color unityBackgroundImageTintColor { get; }
        /// <summary>
        /// Font to draw the element's text, defined as a Font object.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        Font unityFont { get; }
        /// <summary>
        /// Font to draw the element's text, defined as a FontDefinition structure. It takes precedence over `-unity-font`.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        FontDefinition unityFontDefinition { get; }
        /// <summary>
        /// Font style and weight (normal, bold, italic) to draw the element's text.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        FontStyle unityFontStyleAndWeight { get; }
        /// <summary>
        /// Increases or decreases the space between paragraphs.
        /// </summary>
        float unityParagraphSpacing { get; }
        /// <summary>
        /// Size of the 9-slice's bottom edge when painting an element's background image.
        /// </summary>
        int unitySliceBottom { get; }
        /// <summary>
        /// Size of the 9-slice's left edge when painting an element's background image.
        /// </summary>
        int unitySliceLeft { get; }
        /// <summary>
        /// Size of the 9-slice's right edge when painting an element's background image.
        /// </summary>
        int unitySliceRight { get; }
        /// <summary>
        /// Scale applied to an element's slices.
        /// </summary>
        float unitySliceScale { get; }
        /// <summary>
        /// Size of the 9-slice's top edge when painting an element's background image.
        /// </summary>
        int unitySliceTop { get; }
        /// <summary>
        /// Horizontal and vertical text alignment in the element's box.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        TextAnchor unityTextAlign { get; }
        /// <summary>
        /// Outline color of the text.
        /// </summary>
        Color unityTextOutlineColor { get; }
        /// <summary>
        /// Outline width of the text.
        /// </summary>
        float unityTextOutlineWidth { get; }
        /// <summary>
        /// The element's text overflow position.
        /// </summary>
        TextOverflowPosition unityTextOverflowPosition { get; }
        /// <summary>
        /// Specifies whether or not an element is visible.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        Visibility visibility { get; }
        /// <summary>
        /// Word wrap over multiple lines if not enough space is available to draw the text of an element.
        /// </summary>
        /// <remarks>
        /// This property is inherited by default.
        /// </remarks>
        WhiteSpace whiteSpace { get; }
        /// <summary>
        /// Fixed width of an element for the layout.
        /// </summary>
        float width { get; }
        /// <summary>
        /// Increases or decreases the space between words.
        /// </summary>
        float wordSpacing { get; }
    }
}
