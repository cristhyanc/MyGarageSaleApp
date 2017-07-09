using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MyGarageSale.Shared.DTO;

namespace MyGarageSale.Shared
{
    public enum NetworkStatus
    {
        /// <summary>
        /// Network not reachable.
        /// </summary>
        NotReachable,

        /// <summary>
        /// Network reachable via carrier data network.
        /// </summary>
        ReachableViaCarrierDataNetwork,

        /// <summary>
        /// Network reachable via WiFi network.
        /// </summary>
        ReachableViaWiFiNetwork,

        /// <summary>
        /// Network reachable via an unknown network
        /// </summary>
        ReachableViaUnknownNetwork
    }

    public class Constants
    {
        public enum AuditActions
        {
            Insert = 0,
            Updated = 1,
            Deleted = 2
        }
       
        public enum Status
        {
            None=0,
            Active = 1,
            Disable = 2,
        }


        public enum CodeReturns
        {
            Successful = 1000,
            concurrenceProblem = 2000
        }


        public static Object CloneEntity(Object obj)
        {
            Object newObject;
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();
            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            newObject = (Object)dcSer.ReadObject(memoryStream);
            return newObject;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)]
    public class AuditEntity : System.Attribute
    {
        public AuditEntity()
        {

        }
    }

    public class General
    {

        public UserTO  User { get; set; }

        public General(string userId)
        {

            this.UserId = userId;
        }

        public General()
        {
        }


        public string UserId { get; set; }
    }

    public class Helper
    {

        public static IList<SearchDataFormat> ConvertToSearchDataFormat(IList<GarageSaleTO> list)
        {
            IList<SearchDataFormat> result = new List<SearchDataFormat>();
            SearchDataFormat tempdata;
            for (int i = 0; i < list.Count; i++)
            {
                var oldData = list[i];
                tempdata = new SearchDataFormat();
                tempdata.Title1 = oldData.Title;
                tempdata.UrlImage1 = oldData.UrlImage;
                tempdata.Description1 = oldData.Description;
                tempdata.Address1 = oldData.Address;
                tempdata.GarageSaleID1 = oldData.GarageSaleID;
                i++;
                if (i < list.Count)
                {
                    oldData = list[i];
                    tempdata.Title2 = oldData.Title;
                    tempdata.UrlImage2 = oldData.UrlImage;
                    tempdata.Description2 = oldData.Description;
                    tempdata.Address2 = oldData.Address;
                    tempdata.GarageSaleID2 = oldData.GarageSaleID;
                }
                result.Add(tempdata);
            }

            return result;
        }
    }

    public class SearchDataFormat : MainViewModel
    {

        public Guid GarageSaleID1 { get; set; }
        public Guid GarageSaleID2 { get; set; }

        public string Title1 { get; set; }
        public string Title2 { get; set; }

        public string UrlImage1 { get; set; }
        public string UrlImage2 { get; set; }

        public string Description1 { get; set; }
        public string Description2 { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        private bool _liked1;
        private bool _liked2;

        public bool Liked1
        {
            get
            {
                return _liked1;
            }

            set
            {
                LikedImage1 = "Unlike.png";
                _liked1 = value;
                if (value)
                {
                    LikedImage1 = "like.png";
                }
            }
        }

        public bool Liked2
        {
            get
            {
                return _liked2;
            }

            set
            {
                LikedImage2 = "Unlike.png";
                _liked2 = value;
                if (value)
                {
                    LikedImage2 = "like.png";
                }
            }
        }

        private string _likedImage1 = "Unlike.png";
        private string _likedImage2 = "Unlike.png";

        public string LikedImage1
        {
            get
            {
                return _likedImage1;
            }

            set
            {
                _likedImage1 = value;
               
            }

        }

        public string LikedImage2
        {
            get
            {
                return _likedImage2;
            }

            set
            {
                _likedImage2 = value;
               
            }

        }


    }

    public static class Alerts
    {
        public const string SUCCESS = "success";
        public const string ATTENTION = "attention";
        public const string ERROR = "error";
        public const string INFORMATION = "info";

        public static string[] ALL
        {
            get { return new[] { SUCCESS, ATTENTION, INFORMATION, ERROR }; }
        }
    }

}


