﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;

namespace willitfuckingsnow.Adapters
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        Fragment[] _fragments;

        public ViewPagerAdapter(FragmentManager fm, Fragment[] fragments) : base(fm)
        {
            _fragments = fragments;
        }

        public override int Count => _fragments.Length;

        public override Fragment GetItem(int position) => _fragments[position];
    }
}