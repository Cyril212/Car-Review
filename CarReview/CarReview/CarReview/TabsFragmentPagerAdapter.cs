using System;
using Android.Support.V4.App;
using Java.Lang;
namespace CarReview
{
public class TabsFragmentPagerAdapter : FragmentPagerAdapter
{
	private readonly Fragment[] fragments;

	private readonly ICharSequence[] titles;

	public TabsFragmentPagerAdapter(FragmentManager fm,  ICharSequence[] titles) : base(fm)
	{
		//this.fragments = fragments;
		this.titles = titles;


	}
	public override int Count
	{
		get
		{
			return 6;
		}
	}

	public override Fragment GetItem(int position)
	{
			return new Fragment();
	}

	public override ICharSequence GetPageTitleFormatted(int position)
	{
		return titles[position];
	}
}
}
