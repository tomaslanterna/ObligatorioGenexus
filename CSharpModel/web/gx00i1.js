gx.evt.autoSkip=!1;gx.define("gx00i1",!1,function(){var n,t;this.ServerClass="gx00i1";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00i1.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".");this.AV10pEspectaculoFuncionId=gx.fn.getIntegerValue("vPESPECTACULOFUNCIONID",".");this.AV9pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".")};this.e14211_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e11211_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOFUNCIONIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOFUNCIONIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOFUNCIONID","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOFUNCIONIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOFUNCIONID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOFUNCIONID","Visible")',ctrl:"vCESPECTACULOFUNCIONID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12211_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOFUNCIONNAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOFUNCIONNAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOFUNCIONNAME","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOFUNCIONNAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOFUNCIONNAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOFUNCIONNAME","Visible")',ctrl:"vCESPECTACULOFUNCIONNAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e13211_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOFUNCIONPRECIOFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOFUNCIONPRECIOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOFUNCIONPRECIO","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOFUNCIONPRECIOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOFUNCIONPRECIO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONPRECIOFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONPRECIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOFUNCIONPRECIO","Visible")',ctrl:"vCESPECTACULOFUNCIONPRECIO",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e17212_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e18211_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00i1",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(47,46,"ESPECTACULOFUNCIONID","Funcion Id","","EspectaculoFuncionId","int",0,"px",4,4,"right",null,[],47,"EspectaculoFuncionId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(48,47,"ESPECTACULOFUNCIONNAME","Funcion Name","","EspectaculoFuncionName","svchar",0,"px",40,40,"left",null,[],48,"EspectaculoFuncionName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(49,48,"ESPECTACULOFUNCIONPRECIO","Funcion Precio","","EspectaculoFuncionPrecio","int",0,"px",4,4,"right",null,[],49,"EspectaculoFuncionPrecio",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(1,49,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!1,0,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"ESPECTACULOFUNCIONIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLESPECTACULOFUNCIONIDFILTER",format:1,grid:0,evt:"e11211_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOFUNCIONID",fmt:0,gxz:"ZV6cEspectaculoFuncionId",gxold:"OV6cEspectaculoFuncionId",gxvar:"AV6cEspectaculoFuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cEspectaculoFuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cEspectaculoFuncionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOFUNCIONID",gx.O.AV6cEspectaculoFuncionId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cEspectaculoFuncionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOFUNCIONID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"ESPECTACULOFUNCIONNAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLESPECTACULOFUNCIONNAMEFILTER",format:1,grid:0,evt:"e12211_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOFUNCIONNAME",fmt:0,gxz:"ZV7cEspectaculoFuncionName",gxold:"OV7cEspectaculoFuncionName",gxvar:"AV7cEspectaculoFuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cEspectaculoFuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cEspectaculoFuncionName=n)},v2c:function(){gx.fn.setControlValue("vCESPECTACULOFUNCIONNAME",gx.O.AV7cEspectaculoFuncionName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cEspectaculoFuncionName=this.val())},val:function(){return gx.fn.getControlValue("vCESPECTACULOFUNCIONNAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"ESPECTACULOFUNCIONPRECIOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLESPECTACULOFUNCIONPRECIOFILTER",format:1,grid:0,evt:"e13211_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOFUNCIONPRECIO",fmt:0,gxz:"ZV8cEspectaculoFuncionPrecio",gxold:"OV8cEspectaculoFuncionPrecio",gxvar:"AV8cEspectaculoFuncionPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cEspectaculoFuncionPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cEspectaculoFuncionPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOFUNCIONPRECIO",gx.O.AV8cEspectaculoFuncionPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cEspectaculoFuncionPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOFUNCIONPRECIO",".")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"GRIDTABLE",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTOGGLE",grid:0,evt:"e14211_client"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[45]={id:45,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV14Linkselection_GXI)},c2v:function(n){gx.O.AV14Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(44))},gxvar_GXI:"AV14Linkselection_GXI",nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFUNCIONID",fmt:0,gxz:"Z47EspectaculoFuncionId",gxold:"O47EspectaculoFuncionId",gxvar:"A47EspectaculoFuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A47EspectaculoFuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z47EspectaculoFuncionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFUNCIONID",n||gx.fn.currentGridRowImpl(44),gx.O.A47EspectaculoFuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A47EspectaculoFuncionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOFUNCIONID",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFUNCIONNAME",fmt:0,gxz:"Z48EspectaculoFuncionName",gxold:"O48EspectaculoFuncionName",gxvar:"A48EspectaculoFuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A48EspectaculoFuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z48EspectaculoFuncionName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFUNCIONNAME",n||gx.fn.currentGridRowImpl(44),gx.O.A48EspectaculoFuncionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A48EspectaculoFuncionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOFUNCIONNAME",n||gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFUNCIONPRECIO",fmt:0,gxz:"Z49EspectaculoFuncionPrecio",gxold:"O49EspectaculoFuncionPrecio",gxvar:"A49EspectaculoFuncionPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A49EspectaculoFuncionPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z49EspectaculoFuncionPrecio=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFUNCIONPRECIO",n||gx.fn.currentGridRowImpl(44),gx.O.A49EspectaculoFuncionPrecio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A49EspectaculoFuncionPrecio=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOFUNCIONPRECIO",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[49]={id:49,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(44),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(44),".")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"BTN_CANCEL",grid:0,evt:"e18211_client"};this.AV6cEspectaculoFuncionId=0;this.ZV6cEspectaculoFuncionId=0;this.OV6cEspectaculoFuncionId=0;this.AV7cEspectaculoFuncionName="";this.ZV7cEspectaculoFuncionName="";this.OV7cEspectaculoFuncionName="";this.AV8cEspectaculoFuncionPrecio=0;this.ZV8cEspectaculoFuncionPrecio=0;this.OV8cEspectaculoFuncionPrecio=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z47EspectaculoFuncionId=0;this.O47EspectaculoFuncionId=0;this.Z48EspectaculoFuncionName="";this.O48EspectaculoFuncionName="";this.Z49EspectaculoFuncionPrecio=0;this.O49EspectaculoFuncionPrecio=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.AV6cEspectaculoFuncionId=0;this.AV7cEspectaculoFuncionName="";this.AV8cEspectaculoFuncionPrecio=0;this.AV9pEspectaculoId=0;this.AV10pEspectaculoFuncionId=0;this.AV5LinkSelection="";this.A47EspectaculoFuncionId=0;this.A48EspectaculoFuncionName="";this.A49EspectaculoFuncionPrecio=0;this.A1EspectaculoId=0;this.Events={e17212_client:["ENTER",!0],e18211_client:["CANCEL",!0],e14211_client:["'TOGGLE'",!1],e11211_client:["LBLESPECTACULOFUNCIONIDFILTER.CLICK",!1],e12211_client:["LBLESPECTACULOFUNCIONNAMEFILTER.CLICK",!1],e13211_client:["LBLESPECTACULOFUNCIONPRECIOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoFuncionId",fld:"vCESPECTACULOFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoFuncionName",fld:"vCESPECTACULOFUNCIONNAME",pic:""},{av:"AV8cEspectaculoFuncionPrecio",fld:"vCESPECTACULOFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLESPECTACULOFUNCIONIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOFUNCIONID","Visible")',ctrl:"vCESPECTACULOFUNCIONID",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOFUNCIONNAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONNAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONNAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONNAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOFUNCIONNAME","Visible")',ctrl:"vCESPECTACULOFUNCIONNAME",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOFUNCIONPRECIOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONPRECIOFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONPRECIOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOFUNCIONPRECIOFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFUNCIONPRECIOFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOFUNCIONPRECIO","Visible")',ctrl:"vCESPECTACULOFUNCIONPRECIO",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A47EspectaculoFuncionId",fld:"ESPECTACULOFUNCIONID",pic:"ZZZ9",hsh:!0}],[{av:"AV10pEspectaculoFuncionId",fld:"vPESPECTACULOFUNCIONID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoFuncionId",fld:"vCESPECTACULOFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoFuncionName",fld:"vCESPECTACULOFUNCIONNAME",pic:""},{av:"AV8cEspectaculoFuncionPrecio",fld:"vCESPECTACULOFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoFuncionId",fld:"vCESPECTACULOFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoFuncionName",fld:"vCESPECTACULOFUNCIONNAME",pic:""},{av:"AV8cEspectaculoFuncionPrecio",fld:"vCESPECTACULOFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoFuncionId",fld:"vCESPECTACULOFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoFuncionName",fld:"vCESPECTACULOFUNCIONNAME",pic:""},{av:"AV8cEspectaculoFuncionPrecio",fld:"vCESPECTACULOFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoFuncionId",fld:"vCESPECTACULOFUNCIONID",pic:"ZZZ9"},{av:"AV7cEspectaculoFuncionName",fld:"vCESPECTACULOFUNCIONNAME",pic:""},{av:"AV8cEspectaculoFuncionPrecio",fld:"vCESPECTACULOFUNCIONPRECIO",pic:"ZZZ9"},{av:"AV9pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}],[]];this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV10pEspectaculoFuncionId","vPESPECTACULOFUNCIONID",0,"int",4,0);this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);this.setVCMap("AV9pEspectaculoId","vPESPECTACULOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar({rfrVar:"AV9pEspectaculoId"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm({rfrVar:"AV9pEspectaculoId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00i1)})