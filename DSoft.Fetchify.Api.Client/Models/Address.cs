using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DSoft.Fetchify.Api.Client.Models
{
	/// <summary>
	/// Class Address.
	/// </summary>
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
		/// <summary>
		/// Initializes a new instance of the <see cref="Address"/> class.
		/// </summary>
		public Address()
		{

		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the access token.
		/// </summary>
		/// <value>The access token.</value>
		public Guid AccessToken
		{
			get { return _mAccessToken; }
			set { _mAccessToken = value; }
		}
		/// <summary>
		/// Gets or sets the address identifier.
		/// </summary>
		/// <value>The address identifier.</value>
		public int AddressID
		{
			get { return _mAddressId; }
			set { _mAddressId = value; }
		}

		/// <summary>
		/// Gets or sets the line1.
		/// </summary>
		/// <value>The line1.</value>
		public string Line1
		{
			get { return _line1; }
			set { _line1 = value; }
		}

		/// <summary>
		/// Gets or sets the line2.
		/// </summary>
		/// <value>The line2.</value>
		public string Line2
		{
			get { return _line2; }
			set { _line2 = value; }
		}

		/// <summary>
		/// Gets or sets the line3.
		/// </summary>
		/// <value>The line3.</value>
		public string Line3
		{
			get { return _line3; }
			set { _line3 = value; }
		}

		/// <summary>
		/// Gets or sets the town.
		/// </summary>
		/// <value>The town.</value>
		public string Town
		{
			get { return _mTown; }
			set { _mTown = value; }
		}

		/// <summary>
		/// Gets or sets the county.
		/// </summary>
		/// <value>The county.</value>
		public string County
		{
			get { return _mCounty; }
			set { _mCounty = value; }
		}

		/// <summary>
		/// Gets or sets the post code.
		/// </summary>
		/// <value>The post code.</value>
		public string PostCode
		{
			get { return _mPostCode; }
			set { _mPostCode = value; }
		}

		/// <summary>
		/// Gets or sets the department.
		/// </summary>
		/// <value>The department.</value>
		public string Department
		{
			get { return _department; }
			set { _department = value; }
		}

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>The country.</value>
		public string Country
		{
			get { return _country; }
			set { _country = value; }
		}

		/// <summary>
		/// Gets or sets the nation.
		/// </summary>
		/// <value>The nation.</value>
		public string Nation
		{
			get { return _nation; }
			set { _nation = value; }
		}

		/// <summary>
		/// Gets or sets the organisation.
		/// </summary>
		/// <value>The organisation.</value>
		public string Organisation
		{
			get { return _organisation; }
			set { _organisation = value; }
		}

		/// <summary>
		/// Gets or sets the geo location.
		/// </summary>
		/// <value>The geo location.</value>
		public GeoLocation GeoLocation
		{
			get { return _location; }
			set { _location = value; }
		}

		#endregion

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
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

	/// <summary>
	/// GeoLocation model
	/// </summary>
	public class GeoLocation
	{
		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>The latitude.</value>
		public double Latitude { get; set; }

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>The longitude.</value>
		public double Longitude { get; set; }
	}

}
