using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
		private string _country;
		private string _nation;
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

		public string Country
		{
			get { return _country; }
			set { _country = value; }
		}

		public string Nation
		{
			get { return _nation; }
			set { _nation = value; }
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

		public override string ToString()
		{
			var strBuilder = new StringBuilder();

			strBuilder.AppendLine(Environment.NewLine);
			strBuilder.AppendLine("Line 1: " + Line1);
			strBuilder.AppendLine("Line 2: " + Line2);
			strBuilder.AppendLine("Line 3: " + Line3);
			strBuilder.AppendLine("Town: " + Town);
			strBuilder.AppendLine("County: " + County);
			strBuilder.AppendLine("Country: " + Country);
			strBuilder.AppendLine("Post Code: " + PostCode);

			if (this.GeoLocation != null)
			{
				strBuilder.AppendLine($"Corodinates: Lat: {this.GeoLocation.Latitude} Long: {this.GeoLocation.Longitude}");
			}

			return strBuilder.ToString();
		}
	}

	public class GeoLocation
	{
		public double Latitude { get; set; }

		public double Longitude { get; set; }
	}

}
