using ProjectTransportSystem.Forms.AddingsForms.FormForAdd;
using ProjectTransportSystem.Forms.Dictionary;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTransportSystem.Forms.FormGenerator
{
    public interface IDictionaryFormBuilder<T>
        where T : class
    {
        Window GetWindow();
        Window GetWindow(T obj);
    }

    public class BuilderDistanceOnRoadGroup : IDictionaryFormBuilder<DistanceOnRoadGroup>
    {
        public Window GetWindow()
        {
            return new DistanceOnRoadGroupDictionary();
        }

        public Window GetWindow(DistanceOnRoadGroup obj)
        {
            return new DistanceOnRoadGroupDictionary(obj);
        }
    }

    public class BuilderDriver : IDictionaryFormBuilder<DriverAccompanying>
    {
        public Window GetWindow()
        {
            return new DriverAccompanyingDictionary();
        }

        public Window GetWindow(DriverAccompanying obj)
        {
            return new DriverAccompanyingDictionary(obj);
        }
    }

    public class BuilderFuel : IDictionaryFormBuilder<Fuel>
    {
        public Window GetWindow()
        {
            return new FuelDictionary();
        }

        public Window GetWindow(Fuel obj)
        {
            return new FuelDictionary(obj);
        }
    }

    public class BuilderLegalEntity : IDictionaryFormBuilder<LegalEntity>
    {
        public Window GetWindow()
        {
            return new LegalEntityDictionary();
        }

        public Window GetWindow(LegalEntity obj)
        {
            return new LegalEntityDictionary(obj);
        }
    }

    public class BuilderOperation : IDictionaryFormBuilder<Operation>
    {
        public Window GetWindow()
        {
            return new OperationDictionary();
        }

        public Window GetWindow(Operation obj)
        {
            return new OperationDictionary(obj);
        }
    }

    public class BuilderRole : IDictionaryFormBuilder<Role>
    {
        public Window GetWindow()
        {
            return new RoleDictionary();
        }

        public Window GetWindow(Role obj)
        {
            return new RoleDictionary(obj);
        }
    }

    public class BuilderShippingKind : IDictionaryFormBuilder<ShippingKind>
    {
        public Window GetWindow()
        {
            return new ShippingKindDictionary();
        }

        public Window GetWindow(ShippingKind obj)
        {
            return new ShippingKindDictionary(obj);
        }
    }

    public class BuilderTrailerCar : IDictionaryFormBuilder<TrailerCar>
    {
        public Window GetWindow()
        {
            return new TrailerCarDictionary();
        }

        public Window GetWindow(TrailerCar obj)
        {
            return new TrailerCarDictionary(obj);
        }
    }

    public class BuilderTransportType : IDictionaryFormBuilder<TransportType>
    {
        public Window GetWindow()
        {
            return new TransportTypeDictionary();
        }

        public Window GetWindow(TransportType obj)
        {
            return new TransportTypeDictionary(obj);
        }
    }

    public class BuilderWayBill : IDictionaryFormBuilder<WayBill>
    {
        public Window GetWindow()
        {
            return new WayBillForm();
        }

        public Window GetWindow(WayBill obj)
        {
            return new WayBillForm(obj);
        }
    }

    public class BuilderWayList : IDictionaryFormBuilder<WayList>
    {
        public Window GetWindow()
        {
            return new WayListForm();
        }

        public Window GetWindow(WayList obj)
        {
            return new WayListForm(obj);
        }
    }

    public class BuilderContract : IDictionaryFormBuilder<Contract>
    {
        public Window GetWindow()
        {
            return new ContractAdd();
        }

        public Window GetWindow(Contract obj)
        {
            return new ContractAdd(obj);
        }
    }

    public class BuilderCargo : IDictionaryFormBuilder<Cargo>
    {
        public Window GetWindow()
        {
            return new CargoAdd();
        }

        public Window GetWindow(Cargo obj)
        {
            return new CargoAdd(obj);
        }
    }

    public class BuilderAdditionalOperation : IDictionaryFormBuilder<AdditionalOperation>
    {
        public Window GetWindow()
        {
            return new AdditionalOperationAdd();
        }

        public Window GetWindow(AdditionalOperation obj)
        {
            return new AdditionalOperationAdd(obj);
        }
    }

    public class BuilderTrip : IDictionaryFormBuilder<Trip>
    {
        public Window GetWindow()
        {
            return new TripAdd();
        }

        public Window GetWindow(Trip obj)
        {
            return new TripAdd(obj);
        }
    }
}
