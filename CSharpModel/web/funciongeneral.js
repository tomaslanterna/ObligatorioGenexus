gx.evt.autoSkip=!1;gx.define("funciongeneral",!0,function(n){this.ServerClass="funciongeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="funciongeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Funcionid=function(){return this.validCliEvt("Valid_Funcionid",0,function(){try{var n=gx.util.balloon.getNew("FUNCIONID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11161_client=function(){return this.clearMessages(),this.call("funcion.aspx",["UPD",this.A15FuncionId],null,["Mode","FuncionId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12161_client=function(){return this.clearMessages(),this.call("funcion.aspx",["DLT",this.A15FuncionId],null,["Mode","FuncionId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15162_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16162_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e11161_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e12161_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Funcionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONID",fmt:0,gxz:"Z15FuncionId",gxold:"O15FuncionId",gxvar:"A15FuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15FuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15FuncionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FUNCIONID",gx.O.A15FuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15FuncionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FUNCIONID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOFUNCION",fmt:0,gxz:"Z21PrecioFuncion",gxold:"O21PrecioFuncion",gxvar:"A21PrecioFuncion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z21PrecioFuncion=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRECIOFUNCION",gx.O.A21PrecioFuncion,0)},c2v:function(){this.val()!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRECIOFUNCION",".")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONNAME",fmt:0,gxz:"Z22FuncionName",gxold:"O22FuncionName",gxvar:"A22FuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A22FuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z22FuncionName=n)},v2c:function(){gx.fn.setControlValue("FUNCIONNAME",gx.O.A22FuncionName,0)},c2v:function(){this.val()!==undefined&&(gx.O.A22FuncionName=this.val())},val:function(){return gx.fn.getControlValue("FUNCIONNAME")},nac:gx.falseFn};this.A15FuncionId=0;this.Z15FuncionId=0;this.O15FuncionId=0;this.A1EspectaculoId=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.A21PrecioFuncion=0;this.Z21PrecioFuncion=0;this.O21PrecioFuncion=0;this.A22FuncionName="";this.Z22FuncionName="";this.O22FuncionName="";this.A15FuncionId=0;this.A1EspectaculoId=0;this.A21PrecioFuncion=0;this.A22FuncionName="";this.Events={e15162_client:["ENTER",!0],e16162_client:["CANCEL",!0],e11161_client:["'DOUPDATE'",!1],e12161_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_FUNCIONID=[[],[]];this.Initialize()})