gx.evt.autoSkip=!1;gx.define("gx0070",!1,function(){var n,t;this.ServerClass="gx0070";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0070.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV10pFuncionId=gx.fn.getIntegerValue("vPFUNCIONID",".")};this.e151n1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111n1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("FUNCIONIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCFUNCIONID","Visible",!0)):(gx.fn.setCtrlProperty("FUNCIONIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCFUNCIONID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class")',ctrl:"FUNCIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONID","Visible")',ctrl:"vCFUNCIONID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121n1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOID","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOID","Visible")',ctrl:"vCESPECTACULOID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e131n1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("PRECIOFUNCIONFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("PRECIOFUNCIONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCPRECIOFUNCION","Visible",!0)):(gx.fn.setCtrlProperty("PRECIOFUNCIONFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCPRECIOFUNCION","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("PRECIOFUNCIONFILTERCONTAINER","Class")',ctrl:"PRECIOFUNCIONFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRECIOFUNCION","Visible")',ctrl:"vCPRECIOFUNCION",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e141n1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCFUNCIONNAME","Visible",!0)):(gx.fn.setCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCFUNCIONNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"FUNCIONNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONNAME","Visible")',ctrl:"vCFUNCIONNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e181n2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e191n1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,55,56,57,58,59,60,61,62];this.GXLastCtrlId=62;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",54,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0070",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",55,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(15,56,"FUNCIONID","Id","","FuncionId","int",0,"px",4,4,"right",null,[],15,"FuncionId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(1,57,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(21,58,"PRECIOFUNCION","Funcion","","PrecioFuncion","int",0,"px",4,4,"right",null,[],21,"PrecioFuncion",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(22,59,"FUNCIONNAME","Name","","FuncionName","svchar",0,"px",40,40,"left",null,[],22,"FuncionName",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"FUNCIONIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLFUNCIONIDFILTER",format:1,grid:0,evt:"e111n1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCFUNCIONID",fmt:0,gxz:"ZV6cFuncionId",gxold:"OV6cFuncionId",gxvar:"AV6cFuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cFuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cFuncionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCFUNCIONID",gx.O.AV6cFuncionId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cFuncionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCFUNCIONID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"ESPECTACULOIDFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLESPECTACULOIDFILTER",format:1,grid:0,evt:"e121n1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOID",fmt:0,gxz:"ZV7cEspectaculoId",gxold:"OV7cEspectaculoId",gxvar:"AV7cEspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cEspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cEspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOID",gx.O.AV7cEspectaculoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cEspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOID",".")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"PRECIOFUNCIONFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLPRECIOFUNCIONFILTER",format:1,grid:0,evt:"e131n1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCPRECIOFUNCION",fmt:0,gxz:"ZV8cPrecioFuncion",gxold:"OV8cPrecioFuncion",gxvar:"AV8cPrecioFuncion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cPrecioFuncion=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cPrecioFuncion=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCPRECIOFUNCION",gx.O.AV8cPrecioFuncion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cPrecioFuncion=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCPRECIOFUNCION",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"FUNCIONNAMEFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLFUNCIONNAMEFILTER",format:1,grid:0,evt:"e141n1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCFUNCIONNAME",fmt:0,gxz:"ZV9cFuncionName",gxold:"OV9cFuncionName",gxvar:"AV9cFuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cFuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9cFuncionName=n)},v2c:function(){gx.fn.setControlValue("vCFUNCIONNAME",gx.O.AV9cFuncionName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cFuncionName=this.val())},val:function(){return gx.fn.getControlValue("vCFUNCIONNAME")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"GRIDTABLE",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTNTOGGLE",grid:0,evt:"e151n1_client"};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[55]={id:55,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(54))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(54))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[56]={id:56,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONID",fmt:0,gxz:"Z15FuncionId",gxold:"O15FuncionId",gxvar:"A15FuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15FuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15FuncionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("FUNCIONID",n||gx.fn.currentGridRowImpl(54),gx.O.A15FuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15FuncionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("FUNCIONID",n||gx.fn.currentGridRowImpl(54),".")},nac:gx.falseFn};n[57]={id:57,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(54),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(54),".")},nac:gx.falseFn};n[58]={id:58,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOFUNCION",fmt:0,gxz:"Z21PrecioFuncion",gxold:"O21PrecioFuncion",gxvar:"A21PrecioFuncion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z21PrecioFuncion=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRECIOFUNCION",n||gx.fn.currentGridRowImpl(54),gx.O.A21PrecioFuncion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRECIOFUNCION",n||gx.fn.currentGridRowImpl(54),".")},nac:gx.falseFn};n[59]={id:59,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:54,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONNAME",fmt:0,gxz:"Z22FuncionName",gxold:"O22FuncionName",gxvar:"A22FuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A22FuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z22FuncionName=n)},v2c:function(n){gx.fn.setGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(54),gx.O.A22FuncionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A22FuncionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(54))},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"BTN_CANCEL",grid:0,evt:"e191n1_client"};this.AV6cFuncionId=0;this.ZV6cFuncionId=0;this.OV6cFuncionId=0;this.AV7cEspectaculoId=0;this.ZV7cEspectaculoId=0;this.OV7cEspectaculoId=0;this.AV8cPrecioFuncion=0;this.ZV8cPrecioFuncion=0;this.OV8cPrecioFuncion=0;this.AV9cFuncionName="";this.ZV9cFuncionName="";this.OV9cFuncionName="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z15FuncionId=0;this.O15FuncionId=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.Z21PrecioFuncion=0;this.O21PrecioFuncion=0;this.Z22FuncionName="";this.O22FuncionName="";this.AV6cFuncionId=0;this.AV7cEspectaculoId=0;this.AV8cPrecioFuncion=0;this.AV9cFuncionName="";this.AV10pFuncionId=0;this.AV5LinkSelection="";this.A15FuncionId=0;this.A1EspectaculoId=0;this.A21PrecioFuncion=0;this.A22FuncionName="";this.Events={e181n2_client:["ENTER",!0],e191n1_client:["CANCEL",!0],e151n1_client:["'TOGGLE'",!1],e111n1_client:["LBLFUNCIONIDFILTER.CLICK",!1],e121n1_client:["LBLESPECTACULOIDFILTER.CLICK",!1],e131n1_client:["LBLPRECIOFUNCIONFILTER.CLICK",!1],e141n1_client:["LBLFUNCIONNAMEFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV8cPrecioFuncion",fld:"vCPRECIOFUNCION",pic:"ZZZ9"},{av:"AV9cFuncionName",fld:"vCFUNCIONNAME",pic:""}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLFUNCIONIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class")',ctrl:"FUNCIONIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class")',ctrl:"FUNCIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONID","Visible")',ctrl:"vCFUNCIONID",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOID","Visible")',ctrl:"vCESPECTACULOID",prop:"Visible"}]];this.EvtParms["LBLPRECIOFUNCIONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("PRECIOFUNCIONFILTERCONTAINER","Class")',ctrl:"PRECIOFUNCIONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("PRECIOFUNCIONFILTERCONTAINER","Class")',ctrl:"PRECIOFUNCIONFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCPRECIOFUNCION","Visible")',ctrl:"vCPRECIOFUNCION",prop:"Visible"}]];this.EvtParms["LBLFUNCIONNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"FUNCIONNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"FUNCIONNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONNAME","Visible")',ctrl:"vCFUNCIONNAME",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9",hsh:!0}],[{av:"AV10pFuncionId",fld:"vPFUNCIONID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV8cPrecioFuncion",fld:"vCPRECIOFUNCION",pic:"ZZZ9"},{av:"AV9cFuncionName",fld:"vCFUNCIONNAME",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV8cPrecioFuncion",fld:"vCPRECIOFUNCION",pic:"ZZZ9"},{av:"AV9cFuncionName",fld:"vCFUNCIONNAME",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV8cPrecioFuncion",fld:"vCPRECIOFUNCION",pic:"ZZZ9"},{av:"AV9cFuncionName",fld:"vCFUNCIONNAME",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV8cPrecioFuncion",fld:"vCPRECIOFUNCION",pic:"ZZZ9"},{av:"AV9cFuncionName",fld:"vCFUNCIONNAME",pic:""}],[]];this.setVCMap("AV10pFuncionId","vPFUNCIONID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0070)})