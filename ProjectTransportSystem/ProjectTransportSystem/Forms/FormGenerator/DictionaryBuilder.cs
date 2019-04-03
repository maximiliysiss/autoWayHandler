﻿using ProjectTransportSystem.Extensions;
using ProjectTransportSystem.Forms.AddingsForms.FormForAdd;
using ProjectTransportSystem.Forms.Dictionary;
using ProjectTransportSystem.Models;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectTransportSystem.Forms.FormGenerator
{
    public enum DictionaryType
    {
        DistanceOnRoadGroups,
        DriverAccompanyings,
        Fuels,
        LegalEntities,
        Operations,
        Roles,
        ShippingKinds,
        CarTrailers,
        TransportTypes,
        WayLists,
        WayBills,
        Cargoes,
        Contracts,
        AdditionalOperations,
        Trips
    }

    public enum ActionsType
    {
        AddDelete,
        Delete,
        Add,
        Select
    }

    public class DictionaryAction
    {
        public EventHandler EventHandler { get; set; }
        public bool IsShow { get; set; } = true;
    }

    public class DictionaryBuilder
    {
        public IDictionary<string, DictionaryAction> Actions { get; set; } = new Dictionary<string, DictionaryAction>();
        public DictionaryType DictionaryType { get; set; }
        public ActionsType ActionsType { get; set; } = ActionsType.AddDelete;

        public static DictionaryBuilder GetDictionaryBuilder(string name)
        {
            return GetDictionaryBuilder((DictionaryType)Enum.Parse(typeof(DictionaryType), name));
        }

        public static DictionaryBuilder GetDictionaryBuilder(DictionaryType dictionaryType)
        {
            DictionaryBuilder dictionaryBuilder = new DictionaryBuilder { DictionaryType = dictionaryType };

            switch (dictionaryType)
            {
                case DictionaryType.DistanceOnRoadGroups:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderDistanceOnRoadGroup, DistanceOnRoadGroup>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<DistanceOnRoadGroupDictionary, DictionaryTypeDistanseOnRoadGroup>());
                    break;
                case DictionaryType.DriverAccompanyings:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<DriverAccompanyingDictionary, DictionaryTypeDriver>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderDriver, DriverAccompanying>());
                    break;
                case DictionaryType.Fuels:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<FuelDictionary, DictionaryTypeFuel>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderFuel, Fuel>());
                    break;
                case DictionaryType.LegalEntities:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<LegalEntityDictionary, DictionaryTypeLegalEntity>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderLegalEntity, LegalEntity>());
                    break;
                case DictionaryType.Operations:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<OperationDictionary, DictionaryTypeOperation>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderOperation, Operation>());
                    break;
                case DictionaryType.Roles:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<RoleDictionary, DictionaryTypeRole>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderRole, Role>());
                    break;
                case DictionaryType.ShippingKinds:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<ShippingKindDictionary, DictionaryTypeShippingKind>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderShippingKind, ShippingKind>());
                    break;
                case DictionaryType.CarTrailers:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<TrailerCarDictionary, DictionaryTypeCar>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderTrailerCar, TrailerCar>());
                    break;
                case DictionaryType.TransportTypes:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<TransportTypeDictionary, DictionaryTypeTransportType>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderTransportType, TransportType>());
                    break;
                case DictionaryType.WayBills:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<WayBillForm, DictionaryTypeWayBill>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderWayBill, WayBill>());
                    break;
                case DictionaryType.WayLists:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<WayListForm, DictionaryTypeWayList>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderWayList, WayList>());
                    break;
                case DictionaryType.Cargoes:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<CargoAdd, DictionaryTypeCargo>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderCargo, Cargo>());
                    break;
                case DictionaryType.Contracts:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<ContractAdd, DictionaryTypeContract>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderContract, Contract>());
                    break;
                case DictionaryType.AdditionalOperations:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<AdditionalOperationAdd, DictionaryTypeAdditionalOperation>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderAdditionalOperation, AdditionalOperation>());
                    break;
                case DictionaryType.Trips:
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Add<TripAdd, DictionaryTypeTrip>());
                    dictionaryBuilder.Actions.Add(StaticDictionaryActions.Open<BuilderTrip, Trip>());
                    break;
            }
            return dictionaryBuilder;
        }
    }
}
