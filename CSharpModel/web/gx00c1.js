gx.evt.autoSkip=!1;gx.define("gx00c1",!1,function(){var n,t;this.ServerClass="gx00c1";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00c1.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV11pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".");this.AV12pEspectaculoSectorId=gx.fn.getIntegerValue("vPESPECTACULOSECTORID",".");this.AV11pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".")};this.e161i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOSECTORIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOSECTORIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORID","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOSECTORIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORID","Visible")',ctrl:"vCESPECTACULOSECTORID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOSECTORNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOSECTORNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORNAME","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOSECTORNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORNAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORNAME","Visible")',ctrl:"vCESPECTACULOSECTORNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e131i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORCANTIDADASIENTOS","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORCANTIDADASIENTOS","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORCANTIDADASIENTOS","Visible")',ctrl:"vCESPECTACULOSECTORCANTIDADASIENTOS",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e141i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORESTADOSECTOR","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORESTADOSECTOR","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORESTADOSECTOR","Visible")',ctrl:"vCESPECTACULOSECTORESTADOSECTOR",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151i1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOSECTORPRECIOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOSECTORPRECIOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORPRECIO","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOSECTORPRECIOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOSECTORPRECIO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORPRECIOFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORPRECIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORPRECIO","Visible")',ctrl:"vCESPECTACULOSECTORPRECIO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e191i2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e201i1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,65,66,67,68,69,70,71,72,73];this.GXLastCtrlId=73;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",64,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00c1",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",65,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(31,66,"ESPECTACULOSECTORID","Sector Id","","EspectaculoSectorId","int",0,"px",4,4,"right",null,[],31,"EspectaculoSectorId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(32,67,"ESPECTACULOSECTORNAME","Sector Name","","EspectaculoSectorName","svchar",0,"px",40,40,"left",null,[],32,"EspectaculoSectorName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(33,68,"ESPECTACULOSECTORCANTIDADASIEN","Cantidad Asientos","","EspectaculoSectorCantidadAsien","int",0,"px",4,4,"right",null,[],33,"EspectaculoSectorCantidadAsien",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(35,69,"ESPECTACULOSECTORPRECIO","Sector Precio","","EspectaculoSectorPrecio","int",0,"px",4,4,"right",null,[],35,"EspectaculoSectorPrecio",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(1,70,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!1,0,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"ESPECTACULOSECTORIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLESPECTACULOSECTORIDFILTER",format:1,grid:0,evt:"e111i1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOSECTORID",fmt:0,gxz:"ZV6cEspectaculoSectorId",gxold:"OV6cEspectaculoSectorId",gxvar:"AV6cEspectaculoSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cEspectaculoSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cEspectaculoSectorId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOSECTORID",gx.O.AV6cEspectaculoSectorId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cEspectaculoSectorId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOSECTORID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"ESPECTACULOSECTORNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLESPECTACULOSECTORNAMEFILTER",format:1,grid:0,evt:"e121i1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOSECTORNAME",fmt:0,gxz:"ZV7cEspectaculoSectorName",gxold:"OV7cEspectaculoSectorName",gxvar:"AV7cEspectaculoSectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cEspectaculoSectorName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cEspectaculoSectorName=n)},v2c:function(){gx.fn.setControlValue("vCESPECTACULOSECTORNAME",gx.O.AV7cEspectaculoSectorName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cEspectaculoSectorName=this.val())},val:function(){return gx.fn.getControlValue("vCESPECTACULOSECTORNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLESPECTACULOSECTORCANTIDADASIENTOSFILTER",format:1,grid:0,evt:"e131i1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOSECTORCANTIDADASIENTOS",fmt:0,gxz:"ZV8cEspectaculoSectorCantidadAsientos",gxold:"OV8cEspectaculoSectorCantidadAsientos",gxvar:"AV8cEspectaculoSectorCantidadAsientos",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cEspectaculoSectorCantidadAsientos=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cEspectaculoSectorCantidadAsientos=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOSECTORCANTIDADASIENTOS",gx.O.AV8cEspectaculoSectorCantidadAsientos,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cEspectaculoSectorCantidadAsientos=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOSECTORCANTIDADASIENTOS",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLESPECTACULOSECTORESTADOSECTORFILTER",format:1,grid:0,evt:"e141i1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOSECTORESTADOSECTOR",fmt:0,gxz:"ZV9cEspectaculoSectorEstadoSector",gxold:"OV9cEspectaculoSectorEstadoSector",gxvar:"AV9cEspectaculoSectorEstadoSector",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cEspectaculoSectorEstadoSector=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cEspectaculoSectorEstadoSector=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOSECTORESTADOSECTOR",gx.O.AV9cEspectaculoSectorEstadoSector,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cEspectaculoSectorEstadoSector=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOSECTORESTADOSECTOR",".")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"ESPECTACULOSECTORPRECIOFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLESPECTACULOSECTORPRECIOFILTER",format:1,grid:0,evt:"e151i1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOSECTORPRECIO",fmt:0,gxz:"ZV10cEspectaculoSectorPrecio",gxold:"OV10cEspectaculoSectorPrecio",gxvar:"AV10cEspectaculoSectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cEspectaculoSectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cEspectaculoSectorPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOSECTORPRECIO",gx.O.AV10cEspectaculoSectorPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cEspectaculoSectorPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOSECTORPRECIO",".")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"GRIDTABLE",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"BTNTOGGLE",grid:0,evt:"e161i1_client"};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[65]={id:65,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(64),gx.O.AV5LinkSelection,gx.O.AV16Linkselection_GXI)},c2v:function(n){gx.O.AV16Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(64))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(64))},gxvar_GXI:"AV16Linkselection_GXI",nac:gx.falseFn};n[66]={id:66,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOSECTORID",fmt:0,gxz:"Z31EspectaculoSectorId",gxold:"O31EspectaculoSectorId",gxvar:"A31EspectaculoSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A31EspectaculoSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z31EspectaculoSectorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOSECTORID",n||gx.fn.currentGridRowImpl(64),gx.O.A31EspectaculoSectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A31EspectaculoSectorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOSECTORID",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[67]={id:67,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOSECTORNAME",fmt:0,gxz:"Z32EspectaculoSectorName",gxold:"O32EspectaculoSectorName",gxvar:"A32EspectaculoSectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A32EspectaculoSectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z32EspectaculoSectorName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOSECTORNAME",n||gx.fn.currentGridRowImpl(64),gx.O.A32EspectaculoSectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A32EspectaculoSectorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOSECTORNAME",n||gx.fn.currentGridRowImpl(64))},nac:gx.falseFn};n[68]={id:68,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOSECTORCANTIDADASIEN",fmt:0,gxz:"Z33EspectaculoSectorCantidadAsien",gxold:"O33EspectaculoSectorCantidadAsien",gxvar:"A33EspectaculoSectorCantidadAsien",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A33EspectaculoSectorCantidadAsien=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z33EspectaculoSectorCantidadAsien=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOSECTORCANTIDADASIEN",n||gx.fn.currentGridRowImpl(64),gx.O.A33EspectaculoSectorCantidadAsien,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A33EspectaculoSectorCantidadAsien=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOSECTORCANTIDADASIEN",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[69]={id:69,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOSECTORPRECIO",fmt:0,gxz:"Z35EspectaculoSectorPrecio",gxold:"O35EspectaculoSectorPrecio",gxvar:"A35EspectaculoSectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A35EspectaculoSectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z35EspectaculoSectorPrecio=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOSECTORPRECIO",n||gx.fn.currentGridRowImpl(64),gx.O.A35EspectaculoSectorPrecio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A35EspectaculoSectorPrecio=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOSECTORPRECIO",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[70]={id:70,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(64),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"BTN_CANCEL",grid:0,evt:"e201i1_client"};this.AV6cEspectaculoSectorId=0;this.ZV6cEspectaculoSectorId=0;this.OV6cEspectaculoSectorId=0;this.AV7cEspectaculoSectorName="";this.ZV7cEspectaculoSectorName="";this.OV7cEspectaculoSectorName="";this.AV8cEspectaculoSectorCantidadAsientos=0;this.ZV8cEspectaculoSectorCantidadAsientos=0;this.OV8cEspectaculoSectorCantidadAsientos=0;this.AV9cEspectaculoSectorEstadoSector=0;this.ZV9cEspectaculoSectorEstadoSector=0;this.OV9cEspectaculoSectorEstadoSector=0;this.AV10cEspectaculoSectorPrecio=0;this.ZV10cEspectaculoSectorPrecio=0;this.OV10cEspectaculoSectorPrecio=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z31EspectaculoSectorId=0;this.O31EspectaculoSectorId=0;this.Z32EspectaculoSectorName="";this.O32EspectaculoSectorName="";this.Z33EspectaculoSectorCantidadAsien=0;this.O33EspectaculoSectorCantidadAsien=0;this.Z35EspectaculoSectorPrecio=0;this.O35EspectaculoSectorPrecio=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.AV6cEspectaculoSectorId=0;this.AV7cEspectaculoSectorName="";this.AV8cEspectaculoSectorCantidadAsientos=0;this.AV9cEspectaculoSectorEstadoSector=0;this.AV10cEspectaculoSectorPrecio=0;this.AV11pEspectaculoId=0;this.AV12pEspectaculoSectorId=0;this.A34EspectaculoSectorEstadoSector=0;this.AV5LinkSelection="";this.A31EspectaculoSectorId=0;this.A32EspectaculoSectorName="";this.A33EspectaculoSectorCantidadAsien=0;this.A35EspectaculoSectorPrecio=0;this.A1EspectaculoId=0;this.Events={e191i2_client:["ENTER",!0],e201i1_client:["CANCEL",!0],e161i1_client:["'TOGGLE'",!1],e111i1_client:["LBLESPECTACULOSECTORIDFILTER.CLICK",!1],e121i1_client:["LBLESPECTACULOSECTORNAMEFILTER.CLICK",!1],e131i1_client:["LBLESPECTACULOSECTORCANTIDADASIENTOSFILTER.CLICK",!1],e141i1_client:["LBLESPECTACULOSECTORESTADOSECTORFILTER.CLICK",!1],e151i1_client:["LBLESPECTACULOSECTORPRECIOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoSectorId",fld:"vCESPECTACULOSECTORID",pic:"ZZZ9"},{av:"AV7cEspectaculoSectorName",fld:"vCESPECTACULOSECTORNAME",pic:""},{av:"AV8cEspectaculoSectorCantidadAsientos",fld:"vCESPECTACULOSECTORCANTIDADASIENTOS",pic:"ZZZ9"},{av:"AV9cEspectaculoSectorEstadoSector",fld:"vCESPECTACULOSECTORESTADOSECTOR",pic:"ZZZ9"},{av:"AV10cEspectaculoSectorPrecio",fld:"vCESPECTACULOSECTORPRECIO",pic:"ZZZ9"},{av:"AV11pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLESPECTACULOSECTORIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORID","Visible")',ctrl:"vCESPECTACULOSECTORID",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOSECTORNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORNAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORNAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORNAME","Visible")',ctrl:"vCESPECTACULOSECTORNAME",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOSECTORCANTIDADASIENTOSFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORCANTIDADASIENTOSFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORCANTIDADASIENTOS","Visible")',ctrl:"vCESPECTACULOSECTORCANTIDADASIENTOS",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOSECTORESTADOSECTORFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORESTADOSECTORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORESTADOSECTOR","Visible")',ctrl:"vCESPECTACULOSECTORESTADOSECTOR",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOSECTORPRECIOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORPRECIOFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORPRECIOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOSECTORPRECIOFILTERCONTAINER","Class")',ctrl:"ESPECTACULOSECTORPRECIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOSECTORPRECIO","Visible")',ctrl:"vCESPECTACULOSECTORPRECIO",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A31EspectaculoSectorId",fld:"ESPECTACULOSECTORID",pic:"ZZZ9",hsh:!0}],[{av:"AV12pEspectaculoSectorId",fld:"vPESPECTACULOSECTORID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoSectorId",fld:"vCESPECTACULOSECTORID",pic:"ZZZ9"},{av:"AV7cEspectaculoSectorName",fld:"vCESPECTACULOSECTORNAME",pic:""},{av:"AV8cEspectaculoSectorCantidadAsientos",fld:"vCESPECTACULOSECTORCANTIDADASIENTOS",pic:"ZZZ9"},{av:"AV9cEspectaculoSectorEstadoSector",fld:"vCESPECTACULOSECTORESTADOSECTOR",pic:"ZZZ9"},{av:"AV10cEspectaculoSectorPrecio",fld:"vCESPECTACULOSECTORPRECIO",pic:"ZZZ9"},{av:"AV11pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoSectorId",fld:"vCESPECTACULOSECTORID",pic:"ZZZ9"},{av:"AV7cEspectaculoSectorName",fld:"vCESPECTACULOSECTORNAME",pic:""},{av:"AV8cEspectaculoSectorCantidadAsientos",fld:"vCESPECTACULOSECTORCANTIDADASIENTOS",pic:"ZZZ9"},{av:"AV9cEspectaculoSectorEstadoSector",fld:"vCESPECTACULOSECTORESTADOSECTOR",pic:"ZZZ9"},{av:"AV10cEspectaculoSectorPrecio",fld:"vCESPECTACULOSECTORPRECIO",pic:"ZZZ9"},{av:"AV11pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoSectorId",fld:"vCESPECTACULOSECTORID",pic:"ZZZ9"},{av:"AV7cEspectaculoSectorName",fld:"vCESPECTACULOSECTORNAME",pic:""},{av:"AV8cEspectaculoSectorCantidadAsientos",fld:"vCESPECTACULOSECTORCANTIDADASIENTOS",pic:"ZZZ9"},{av:"AV9cEspectaculoSectorEstadoSector",fld:"vCESPECTACULOSECTORESTADOSECTOR",pic:"ZZZ9"},{av:"AV10cEspectaculoSectorPrecio",fld:"vCESPECTACULOSECTORPRECIO",pic:"ZZZ9"},{av:"AV11pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoSectorId",fld:"vCESPECTACULOSECTORID",pic:"ZZZ9"},{av:"AV7cEspectaculoSectorName",fld:"vCESPECTACULOSECTORNAME",pic:""},{av:"AV8cEspectaculoSectorCantidadAsientos",fld:"vCESPECTACULOSECTORCANTIDADASIENTOS",pic:"ZZZ9"},{av:"AV9cEspectaculoSectorEstadoSector",fld:"vCESPECTACULOSECTORESTADOSECTOR",pic:"ZZZ9"},{av:"AV10cEspectaculoSectorPrecio",fld:"vCESPECTACULOSECTORPRECIO",pic:"ZZZ9"},{av:"AV11pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.setVCMap("AV11pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV12pEspectaculoSectorId","vPESPECTACULOSECTORID",0,"int",4,0);this.setVCMap("AV11pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV11pEspectaculoId","vPESPECTACULOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar({rfrVar:"AV11pEspectaculoId"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm({rfrVar:"AV11pEspectaculoId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00c1)})