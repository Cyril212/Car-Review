using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;

namespace CarReview
{
	public class SlidingTabStrip : LinearLayout
	{
private const int DEFAULT_BOTTOM_BORDER_THICKNESS_DIPS = 2;
private const byte DEFAULT_BOTTOM_BORDER_COLOR_ALPHA = 0X26;
private const int SELECTED_INDICATION_THICKNESS_DIPS = 8;
		private int[] INDICATOR_COLORS = { 0x19A319, 0x0000FC };
		private int[] DIVIDER_COLORS = { 0xC5C5C5 };

		private const int DEFAULT_DIVIDER_THICKNESS_DIPS = 1;
		private const float DEFAULT_DIVIDER_HEIGHT = 0.5f;

		private int mBottomBorderThickness;
		private Paint mBottomBordorPaint;
		private int mDefaultBottomBorderColor;

		private int mSelectedIndicatorThickness;
		private Paint mSelectedIndicatorPaint;

		private Paint mDividerPaint;
		private float mDividerHeight;

		private int mSelectedPosition;
		private float mSelectionOffset;

		private SlidingTabScrollView.TabColorizer mCustomTabColorizer;
		private SimpleTabColorizer mDefaultTabColorizer;
		public SlidingTabStrip(Context context) :this(context,null)
		{

		}

		public SlidingTabStrip(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			SetWillNotDraw(false);

			float density = Resources.DisplayMetrics.Density;

			TypedValue outValue = new TypedValue();

			context.Theme.ResolveAttribute(Android.Resource.Attribute.ColorForeground, outValue, true);
			       int themeForeGround = outValue.Data;

			mDefaultBottomBorderColor = SetColorAlpha(themeForeGround, DEFAULT_BOTTOM_BORDER_COLOR_ALPHA);


		}
 	}
}
