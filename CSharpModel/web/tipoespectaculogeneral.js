gx.evt.autoSkip=!1;gx.define("tipoespectaculogeneral",!0,function(n){this.ServerClass="tipoespectaculogeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="tipoespectaculogeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Tipoespectaculoid=function(){return this.validCliEvt("Valid_Tipoespectaculoid",0,function(){try{var n=gx.util.balloon.getNew("TIPOESPECTACULOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11121_client=function(){return this.clearMessages(),this.call("tipoespectaculo.aspx",["UPD",this.A7TipoEspectaculoId],null,["Mode","TipoEspectaculoId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12121_client=function(){return this.clearMessages(),this.call("tipoespectaculo.aspx",["DLT",this.A7TipoEspectaculoId],null,["Mode","TipoEspectaculoId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15122_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16122_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23];this.GXLastCtrlId=23;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e11121_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e12121_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Tipoespectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULOID",fmt:0,gxz:"Z7TipoEspectaculoId",gxold:"O7TipoEspectaculoId",gxvar:"A7TipoEspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A7TipoEspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7TipoEspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("TIPOESPECTACULOID",gx.O.A7TipoEspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A7TipoEspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("TIPOESPECTACULOID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULONAME",fmt:0,gxz:"Z8TipoEspectaculoName",gxold:"O8TipoEspectaculoName",gxvar:"A8TipoEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8TipoEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8TipoEspectaculoName=n)},v2c:function(){gx.fn.setControlValue("TIPOESPECTACULONAME",gx.O.A8TipoEspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8TipoEspectaculoName=this.val())},val:function(){return gx.fn.getControlValue("TIPOESPECTACULONAME")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});this.A7TipoEspectaculoId=0;this.Z7TipoEspectaculoId=0;this.O7TipoEspectaculoId=0;this.A8TipoEspectaculoName="";this.Z8TipoEspectaculoName="";this.O8TipoEspectaculoName="";this.A7TipoEspectaculoId=0;this.A8TipoEspectaculoName="";this.Events={e15122_client:["ENTER",!0],e16122_client:["CANCEL",!0],e11121_client:["'DOUPDATE'",!1],e12121_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_TIPOESPECTACULOID=[[],[]];this.Initialize()})