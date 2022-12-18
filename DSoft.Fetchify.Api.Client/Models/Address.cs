using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.Fetchify.Api.Client.Models
{
	public class Address
	{
		#region Private variables

		private int _mAddressId;
		private string _line1;
		private string _line2;
		private string _line3;
		private string _mTown;
		private string _mCounty;
		private string _mPostCode;
		private Guid _mAccessToken;
		private string _organisation;
		private string _department;
		private GeoLocation _location;
		#endregion

		#region Constructor
		public Address()
		{

		}

		#endregion

		#region Properties
		public Guid AccessToken
		{
			get { return _mAccessToken; }
			set { _mAccessToken = value; }
		}
		public int AddressID
		{
			get { return _mAddressId; }
			set { _mAddressId = value; }
		}

		public string Line1
		{
			get { return _line1; }
			set { _line1 = value; }
		}

		public string Line2
		{
			get { return _line2; }
			set { _line2 = value; }
		}

		public string Line3
		{
			get { return _line3; }
			set { _line3 = value; }
		}

		public string Town
		{
			get { return _mTown; }
			set { _mTown = value; }
		}

		public string County
		{
			get { return _mCounty; }
			set { _mCounty = value; }
		}

		public string PostCode
		{
			get { return _mPostCode; }
			set { _mPostCode = value; }
		}

		public string Department
		{
			get { return _department; }
			set { _department = value; }
		}


		public string Organisation
		{
			get { return _organisation; }
			set { _organisation = value; }
		}

		public GeoLocation GeoLocation
		{
			get { return _location; }
			set { _location = value; }
		}

		#endregion
	}

	public class GeoLocation
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }
	}

}
