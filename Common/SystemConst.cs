using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class SystemConst
    {
        public const string Versions = "DCScrapTool Tool  _V 0.1";
        public const string RFC = "BBP_RFC_READ_TABLE";
        public const string DELIMITER = "|";
        public const string ExcelFilter = "Excel File|*.xlsx;*.xls";
        public static string CurrentSAPCnn;
        public static string DateTimeFormat = "yyyy/MM/dd";
        
        //excel for db fields
        public const string recfields_ABC = "Material,Material Description,ABC Classification";
        public const string desfields_ABC = "Material,Description,FinalABC";



        public const string recfields_CRSlist = "Ship-to Code,门店名称           (限6个中文字),客户核单人电话      如有多个电话，请以英文状态下的逗号分隔),是否使用短信确认订单,CO CSR,CO email,CSR Ext #,SO DA,SO email,Channel,Market,Banner,RDC,PLANT CODE,SAP Sold-to Code,SAP Ship-to Code,Sold-to Name in Chinese,Ship-to address,C/DTLM,Email Address,Phone#";
        public const string desfields_CRSlist = "ShiptoCode,Cname,CPhones,IsMessg,COCSR,COemail,CSRExt,SODA,SOemail,Channel,Market,Banner,RDC,PLANTCODE,SAPSoldtoCode,SAPShiptoCode,SoldtoNameinChinese,Shiptoaddress,CDTLM,EmailAddress,Phone";

        public const string recfields_Summary = "Plant,Material,Date / Time,Scheduled Date,Scheduled Time,Type,Document,Item,Quantity,Confirmed qty,Remaining qty,Rec./Sending plant,Comment,Ship-to,Sold-to,PO Number,order Reason,Category,Brand,Description,Versions";
        public const string desfields_Summary = "Plant,Material,DateTime,ScheduledDate,ScheduledTime,Type,Document,Item,Quantity,Confirmedqty,Remainingqty,RecSendingplant,Comment,Shipto,Soldto,PONumber,OrderReason,Category,Brand,Description,Versions";

        public const string recfields_OOS = "Category,OOS(MSU) By plant ,Item(MSU) 列,OOS(MSU) ,OOS(CS) ,Brand,MRP Controller,Plant,Ship-to,Customer name(中文),Saler order#,PO#,Material,中文描述 (Chinese description for product),Order Qty,Confirmed Qty,Shortage,RDT,RDD,Forecast,Order/Fcst,Substitution code,QM lot qty,QM lot batch number,QM lot qty,QM lot batch number,QM lot qty,QM lot batch number,In-transit date (Shipnt & Purorder),In transit qty,Delivery#,In-transit date (Shipnt & Purorder),In transit qty,Delivery#,In-transit date (Shipnt & Purorder),In transit qty,Delivery#,process order qty,process order date,process order plant,process order qty,process order date,process order plant,process order qty,process order date,process order plant,process order qty,process order date,process order plant,Source site";
        public const string desfields_OOS = "Category,OOSbyitemlineMSU,OOSByPlantByMaterialMSU,OOSMSU,OOSCS,Brand,MRPController,Plant,Shipto,CustomerName,SalerOrder,PO,Material,ChineseDescriptionForProduct,OrderQty,ConfirmedQty,Shortage,RDT,RDD,Forecast,OrderFcst,SubstitutionCode,QMLotQty1,QMLotBatchNumber1,QMLotQty2,QMLotBatchNumber2,QMLotQty3,QMLotBatchNumber3,IntransitDate1,IntransitqQty1,Delivery1,IntransitDate2,IntransitqQty2,Delivery2,IntransitDate3,IntransitqQty3,Delivery3,ProcessOrderQty1,ProcessOrderDate1,ProcessDrderPlant1,ProcessOrderQty2,ProcessOrderDate2,ProcessDrderPlant2,ProcessOrderQty3,ProcessOrderDate3,ProcessDrderPlant3,ProcessOrderQty4,ProcessOrderDate4,ProcessDrderPlant4,SourceSite,Versions";

        public const string desfields_AllOrder = "Category,OOSMSU,OOSCS,Brand,MRPController,Plant,ShipToCode,CustomerName,SalesOrder,POCode,Material,ChineseMaterialDescription,OrderQty,ConfirmedQty,Shortage,OOSbyitemlineMSU,OrderFcst,OrderEnterTiming,RDD,SubstitutionCode,QMlotqty1,Qmlotbatchnumber1,QMlotqty2,QMlotbatchnumber2,QMlotqty3,QMlotbatchnumber3,Intransitdate1,Intransitqty1,Delivery1,Intransitdate2,Intransitqty2,Delivery2,Intransitdate3,Intransitqty3,Delivery3,ProcessOrderQty1,ProcessOrderDate1,ProcessOrderPlant1,ProcessOrderQty2,ProcessOrderDate2,ProcessOrderPlant2,ProcessOrderQty3,ProcessOrderDate3,ProcessOrderPlant3,ProcessOrderQty4,ProcessOrderDate4,ProcessOrderPlant4,Versions";

        public const string recfields_CostMap = "Route,ship from,ship to,OTD,Distance (KM),Unit Cost (RMB/KM/Ton),MOQ (ton),Supplier,Province,Unloading Fee";
        public const string desfields_CostMap = "Route,ShipFrom,ShipTo,OTD,DistanceKM,UnitCostRmbKmTon,MOQTon,Supplier,Province,UnloadingFee";

        public const string recfields_Category = "Item Code,Category,Segment";
        public const string desfields_Category = "ItemCode,CategoryName,Segment";

        public const string recfields_DefaultDC = "Plant,XDC1,XDC2";
        public const string desfields_DefaultDC = "Plant,XDC1,XDC2";

        public const string recfields_BO = "Date,DRPer,GN#,RDC,Ship-to,Customer Name,P&G Order#,Customer PO number,Item Code,Chinese Description,Customer Original Order,Today's fulfillment,Detail Solution,CSR";
        public const string desfields_BO = "Date,DRPer,Phone,RDC,Shipto,CustomerName,SalerOrder,CustomerPO,ItemCode,ChineseDescription,OrderQty,TodaysFulfillment,DetailSolution,CSR";

        public const string recfields_CaseRate = "Category,Vol (MSU),NOS ($MM),TDC ($MM)";
        public const string desfields_CaseRate = "Category,VolMSU,NOSMM,TDCMM";

        public const string recfields_Shipto = "Ship-to,Sold-to Name,Ship-to City,Channel,Sold-to,Self Unload,Province,Delivery Plant,T-Zone Code,Active?,Division,Market,Banner";
        public const string desfields_Shipto = "ShipTo,SoldToName,ShipToCity,Channel,SoldTo,SelfUnload,Province,DeliveryPlant,TZoneCode,Active,Division,Market,Banner";

        public const string recfields_XDCdetail = "Order Date,Ship from City,Support DC,Ship To City,Route,Ship-to Code,Customer Name,Distance (KM),Category,Segment,Vol (MSU),Sales Order #,Material Code,Quantity (Case),CSR list";
        public const string desfields_XDCdetail = "OrderDate,ShipFromCity,SupportDC,ShipToCity,Route,ShipToCode,CustomerName,Distance,Category,Segment,Vol,SalesOrder,MaterialCode,Quantity,CSRlist";

        public const string recfields_ProductMatrix = "Group,Old,New,Default";
        public const string desfields_ProductMatrix = "Mgroup,OldM,NewM,DefaultM";
    }
}
