gx.evt.autoSkip=!1;gx.define("gx00d1",!1,function(){var n,t;this.ServerClass="gx00d1";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00d1.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".");this.AV10pLugarSectorId=gx.fn.getIntegerValue("vPLUGARSECTORID",".");this.AV9pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".")};this.e131r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("LUGARSECTORIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("LUGARSECTORIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCLUGARSECTORID","Visible",!0)):(gx.fn.setCtrlProperty("LUGARSECTORIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCLUGARSECTORID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("LUGARSECTORIDFILTERCONTAINER","Class")',ctrl:"LUGARSECTORIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCLUGARSECTORID","Visible")',ctrl:"vCLUGARSECTORID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121r1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("LUGARSECTORESTADOSECTORFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("LUGARSECTORESTADOSECTORFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCLUGARSECTORESTADOSECTOR","Visible",!0)):(gx.fn.setCtrlProperty("LUGARSECTORESTADOSECTORFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCLUGARSECTORESTADOSECTOR","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("LUGARSECTORESTADOSECTORFILTERCONTAINER","Class")',ctrl:"LUGARSECTORESTADOSECTORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCLUGARSECTORESTADOSECTOR","Visible")',ctrl:"vCLUGARSECTORESTADOSECTOR",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e161r2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e171r1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,35,36,37,38,39,40,41];this.GXLastCtrlId=41;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",34,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00d1",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",35,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(27,36,"LUGARSECTORID","Sector Id","","LugarSectorId","int",0,"px",4,4,"right",null,[],27,"LugarSectorId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addCheckBox(41,37,"LUGARSECTORESTADOSECTOR","Estado Sector","","LugarSectorEstadoSector","boolean","true","false",null,!0,!1,0,"px","WWColumn");t.addSingleLineEdit(1,38,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!1,0,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"LUGARSECTORIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLLUGARSECTORIDFILTER",format:1,grid:0,evt:"e111r1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCLUGARSECTORID",fmt:0,gxz:"ZV6cLugarSectorId",gxold:"OV6cLugarSectorId",gxvar:"AV6cLugarSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cLugarSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cLugarSectorId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCLUGARSECTORID",gx.O.AV6cLugarSectorId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cLugarSectorId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCLUGARSECTORID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"LUGARSECTORESTADOSECTORFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLLUGARSECTORESTADOSECTORFILTER",format:1,grid:0,evt:"e121r1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCLUGARSECTORESTADOSECTOR",fmt:0,gxz:"ZV8cLugarSectorEstadoSector",gxold:"OV8cLugarSectorEstadoSector",gxvar:"AV8cLugarSectorEstadoSector",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.AV8cLugarSectorEstadoSector=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cLugarSectorEstadoSector=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("vCLUGARSECTORESTADOSECTOR",gx.O.AV8cLugarSectorEstadoSector,!0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cLugarSectorEstadoSector=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("vCLUGARSECTORESTADOSECTOR")},nac:gx.falseFn,values:["true","false"]};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"GRIDTABLE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTOGGLE",grid:0,evt:"e131r1_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(34))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(34))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[36]={id:36,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORID",fmt:0,gxz:"Z27LugarSectorId",gxold:"O27LugarSectorId",gxvar:"A27LugarSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27LugarSectorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(34),gx.O.A27LugarSectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(34),".")},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORESTADOSECTOR",fmt:0,gxz:"Z41LugarSectorEstadoSector",gxold:"O41LugarSectorEstadoSector",gxvar:"A41LugarSectorEstadoSector",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A41LugarSectorEstadoSector=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z41LugarSectorEstadoSector=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("LUGARSECTORESTADOSECTOR",n||gx.fn.currentGridRowImpl(34),gx.O.A41LugarSectorEstadoSector,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A41LugarSectorEstadoSector=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("LUGARSECTORESTADOSECTOR",n||gx.fn.currentGridRowImpl(34))},nac:gx.falseFn,values:["true","false"]};n[38]={id:38,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:34,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(34),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(34),".")},nac:gx.falseFn};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTN_CANCEL",grid:0,evt:"e171r1_client"};this.AV6cLugarSectorId=0;this.ZV6cLugarSectorId=0;this.OV6cLugarSectorId=0;this.AV8cLugarSectorEstadoSector=!1;this.ZV8cLugarSectorEstadoSector=!1;this.OV8cLugarSectorEstadoSector=!1;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z27LugarSectorId=0;this.O27LugarSectorId=0;this.Z41LugarSectorEstadoSector=!1;this.O41LugarSectorEstadoSector=!1;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.AV6cLugarSectorId=0;this.AV8cLugarSectorEstadoSector=!1;this.AV9pEspectaculoId=0;this.AV10pLugarSectorId=0;this.AV5LinkSelection="";this.A27LugarSectorId=0;this.A41LugarSectorEstadoSector=!1;this.A1EspectaculoId=0;this.Events={e161r2_client:["ENTER",!0],e171r1_client:["CANCEL",!0],e131r1_client:["'TOGGLE'",!1],e111r1_client:["LBLLUGARSECTORIDFILTER.CLICK",!1],e121r1_client:["LBLLUGARSECTORESTADOSECTORFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cLugarSectorId",fld:"vCLUGARSECTORID",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"},{av:"AV8cLugarSectorEstadoSector",fld:"vCLUGARSECTORESTADOSECTOR",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLLUGARSECTORIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("LUGARSECTORIDFILTERCONTAINER","Class")',ctrl:"LUGARSECTORIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("LUGARSECTORIDFILTERCONTAINER","Class")',ctrl:"LUGARSECTORIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCLUGARSECTORID","Visible")',ctrl:"vCLUGARSECTORID",prop:"Visible"}]];this.EvtParms["LBLLUGARSECTORESTADOSECTORFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("LUGARSECTORESTADOSECTORFILTERCONTAINER","Class")',ctrl:"LUGARSECTORESTADOSECTORFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("LUGARSECTORESTADOSECTORFILTERCONTAINER","Class")',ctrl:"LUGARSECTORESTADOSECTORFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCLUGARSECTORESTADOSECTOR","Visible")',ctrl:"vCLUGARSECTORESTADOSECTOR",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A27LugarSectorId",fld:"LUGARSECTORID",pic:"ZZZ9",hsh:!0}],[{av:"AV10pLugarSectorId",fld:"vPLUGARSECTORID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cLugarSectorId",fld:"vCLUGARSECTORID",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"},{av:"AV8cLugarSectorEstadoSector",fld:"vCLUGARSECTORESTADOSECTOR",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cLugarSectorId",fld:"vCLUGARSECTORID",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"},{av:"AV8cLugarSectorEstadoSector",fld:"vCLUGARSECTORESTADOSECTOR",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cLugarSectorId",fld:"vCLUGARSECTORID",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"},{av:"AV8cLugarSectorEstadoSector",fld:"vCLUGARSECTORESTADOSECTOR",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cLugarSectorId",fld:"vCLUGARSECTORID",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"},{av:"AV8cLugarSectorEstadoSector",fld:"vCLUGARSECTORESTADOSECTOR",pic:""}],[]];this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV10pLugarSectorId","vPLUGARSECTORID",0,"int",4,0);this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar({rfrVar:"AV9pEspectaculoId"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm({rfrVar:"AV9pEspectaculoId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00d1)})