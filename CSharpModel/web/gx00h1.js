gx.evt.autoSkip=!1;gx.define("gx00h1",!1,function(){var n,t;this.ServerClass="gx00h1";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00h1.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".");this.AV10pFuncionId=gx.fn.getIntegerValue("vPFUNCIONID",".");this.AV9pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".")};this.e14201_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11201_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("FUNCIONIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCFUNCIONID","Visible",!0)):(gx.fn.setCtrlProperty("FUNCIONIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCFUNCIONID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class")',ctrl:"FUNCIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONID","Visible")',ctrl:"vCFUNCIONID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12201_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCFUNCIONNAME","Visible",!0)):(gx.fn.setCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCFUNCIONNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"FUNCIONNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONNAME","Visible")',ctrl:"vCFUNCIONNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13201_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("FUNCIONPRECIOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("FUNCIONPRECIOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCFUNCIONPRECIO","Visible",!0)):(gx.fn.setCtrlProperty("FUNCIONPRECIOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCFUNCIONPRECIO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("FUNCIONPRECIOFILTERCONTAINER","Class")',ctrl:"FUNCIONPRECIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONPRECIO","Visible")',ctrl:"vCFUNCIONPRECIO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e17202_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e18201_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00h1",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(15,46,"FUNCIONID","Id","","FuncionId","int",0,"px",4,4,"right",null,[],15,"FuncionId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(22,47,"FUNCIONNAME","Name","","FuncionName","svchar",0,"px",40,40,"left",null,[],22,"FuncionName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(46,48,"FUNCIONPRECIO","Precio","","FuncionPrecio","int",0,"px",4,4,"right",null,[],46,"FuncionPrecio",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(1,49,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!1,0,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"FUNCIONIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLFUNCIONIDFILTER",format:1,grid:0,evt:"e11201_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCFUNCIONID",fmt:0,gxz:"ZV6cFuncionId",gxold:"OV6cFuncionId",gxvar:"AV6cFuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cFuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cFuncionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCFUNCIONID",gx.O.AV6cFuncionId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cFuncionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCFUNCIONID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"FUNCIONNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLFUNCIONNAMEFILTER",format:1,grid:0,evt:"e12201_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCFUNCIONNAME",fmt:0,gxz:"ZV7cFuncionName",gxold:"OV7cFuncionName",gxvar:"AV7cFuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cFuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cFuncionName=n)},v2c:function(){gx.fn.setControlValue("vCFUNCIONNAME",gx.O.AV7cFuncionName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cFuncionName=this.val())},val:function(){return gx.fn.getControlValue("vCFUNCIONNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"FUNCIONPRECIOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLFUNCIONPRECIOFILTER",format:1,grid:0,evt:"e13201_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCFUNCIONPRECIO",fmt:0,gxz:"ZV8cFuncionPrecio",gxold:"OV8cFuncionPrecio",gxvar:"AV8cFuncionPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cFuncionPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cFuncionPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCFUNCIONPRECIO",gx.O.AV8cFuncionPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cFuncionPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCFUNCIONPRECIO",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"GRIDTABLE",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTOGGLE",grid:0,evt:"e14201_client"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[45]={id:45,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(44))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONID",fmt:0,gxz:"Z15FuncionId",gxold:"O15FuncionId",gxvar:"A15FuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15FuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15FuncionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("FUNCIONID",n||gx.fn.currentGridRowImpl(44),gx.O.A15FuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15FuncionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("FUNCIONID",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONNAME",fmt:0,gxz:"Z22FuncionName",gxold:"O22FuncionName",gxvar:"A22FuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A22FuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z22FuncionName=n)},v2c:function(n){gx.fn.setGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(44),gx.O.A22FuncionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A22FuncionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONPRECIO",fmt:0,gxz:"Z46FuncionPrecio",gxold:"O46FuncionPrecio",gxvar:"A46FuncionPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A46FuncionPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z46FuncionPrecio=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("FUNCIONPRECIO",n||gx.fn.currentGridRowImpl(44),gx.O.A46FuncionPrecio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A46FuncionPrecio=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("FUNCIONPRECIO",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[49]={id:49,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(44),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTN_CANCEL",grid:0,evt:"e18201_client"};this.AV6cFuncionId=0;this.ZV6cFuncionId=0;this.OV6cFuncionId=0;this.AV7cFuncionName="";this.ZV7cFuncionName="";this.OV7cFuncionName="";this.AV8cFuncionPrecio=0;this.ZV8cFuncionPrecio=0;this.OV8cFuncionPrecio=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z15FuncionId=0;this.O15FuncionId=0;this.Z22FuncionName="";this.O22FuncionName="";this.Z46FuncionPrecio=0;this.O46FuncionPrecio=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.AV6cFuncionId=0;this.AV7cFuncionName="";this.AV8cFuncionPrecio=0;this.AV9pEspectaculoId=0;this.AV10pFuncionId=0;this.AV5LinkSelection="";this.A15FuncionId=0;this.A22FuncionName="";this.A46FuncionPrecio=0;this.A1EspectaculoId=0;this.Events={e17202_client:["ENTER",!0],e18201_client:["CANCEL",!0],e14201_client:["'TOGGLE'",!1],e11201_client:["LBLFUNCIONIDFILTER.CLICK",!1],e12201_client:["LBLFUNCIONNAMEFILTER.CLICK",!1],e13201_client:["LBLFUNCIONPRECIOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cFuncionName",fld:"vCFUNCIONNAME",pic:""},{av:"AV8cFuncionPrecio",fld:"vCFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLFUNCIONIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class")',ctrl:"FUNCIONIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FUNCIONIDFILTERCONTAINER","Class")',ctrl:"FUNCIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONID","Visible")',ctrl:"vCFUNCIONID",prop:"Visible"}]];this.EvtParms["LBLFUNCIONNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"FUNCIONNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"FUNCIONNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONNAME","Visible")',ctrl:"vCFUNCIONNAME",prop:"Visible"}]];this.EvtParms["LBLFUNCIONPRECIOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("FUNCIONPRECIOFILTERCONTAINER","Class")',ctrl:"FUNCIONPRECIOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("FUNCIONPRECIOFILTERCONTAINER","Class")',ctrl:"FUNCIONPRECIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCFUNCIONPRECIO","Visible")',ctrl:"vCFUNCIONPRECIO",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9",hsh:!0}],[{av:"AV10pFuncionId",fld:"vPFUNCIONID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cFuncionName",fld:"vCFUNCIONNAME",pic:""},{av:"AV8cFuncionPrecio",fld:"vCFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cFuncionName",fld:"vCFUNCIONNAME",pic:""},{av:"AV8cFuncionPrecio",fld:"vCFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cFuncionName",fld:"vCFUNCIONNAME",pic:""},{av:"AV8cFuncionPrecio",fld:"vCFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cFuncionId",fld:"vCFUNCIONID",pic:"ZZZ9"},{av:"AV7cFuncionName",fld:"vCFUNCIONNAME",pic:""},{av:"AV8cFuncionPrecio",fld:"vCFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV10pFuncionId","vPFUNCIONID",0,"int",4,0);this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar({rfrVar:"AV9pEspectaculoId"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm({rfrVar:"AV9pEspectaculoId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00h1)})