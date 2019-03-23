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
}
