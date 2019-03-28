using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Forms.FormGenerator
{
    public interface IDictionaryType
    {
        DictionaryType DictionaryType { get; }
    }

    public class DictionaryTypeDistanseOnRoadGroup : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.DistanceOnRoadGroups;
    }

    public class DictionaryTypeDriver : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.DriverAccompanyings;
    }

    public class DictionaryTypeFuel : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.Fuels;
    }

    public class DictionaryTypeLegalEntity : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.LegalEntities;
    }

    public class DictionaryTypeOperation : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.Operations;
    }

    public class DictionaryTypeRole : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.Roles;
    }

    public class DictionaryTypeShippingKind : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.ShippingKinds;
    }

    public class DictionaryTypeCar : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.CarTrailers;
    }

    public class DictionaryTypeTransportType : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.TransportTypes;
    }

    public class DictionaryTypeWayBill : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.WayBills;
    }

    public class DictionaryTypeWayList : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.WayLists;
    }

    public class DictionaryTypeContract : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.Contracts;
    }

    public class DictionaryTypeCargo : IDictionaryType
    {
        public DictionaryType DictionaryType => DictionaryType.Cargoes;
    }
}
