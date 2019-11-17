using Android.Content;
using Android.Database;
using Android.Net;
using System;
using Uri = Android.Net.Uri;

namespace willitfuckingsnow.Data
{
    public class WeatherStateProvider : ContentProvider
    {
        public override int Delete(Uri uri, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }

        public override string GetType(Uri uri)
        {
            throw new NotImplementedException();
        }

        public override Uri Insert(Uri uri, ContentValues values)
        {
            throw new NotImplementedException();
        }

        public override bool OnCreate()
        {
            throw new NotImplementedException();
        }

        public override ICursor Query(Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public override int Update(Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }
    }
}
