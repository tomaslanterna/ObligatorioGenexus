gx.evt.autoSkip=!1;gx.define("funcion",!1,function(){this.ServerClass="funcion";this.PackageName="GeneXus.Programs";this.ServerFullClass="funcion.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7FuncionId=gx.fn.getIntegerValue("vFUNCIONID",".");this.AV11Insert_EspectaculoId=gx.fn.getIntegerValue("vINSERT_ESPECTACULOID",".");this.AV13Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Funcionid=function(){return this.validCliEvt("Valid_Funcionid",0,function(){try{var n=gx.util.balloon.getNew("FUNCIONID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){return this.validSrvEvt("Valid_Espectaculoid",0).then(function(n){return n}.closure(this))};this.e12072_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13077_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14077_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59];this.GXLastCtrlId=59;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15077_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16077_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17077_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18077_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19077_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Funcionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONID",fmt:0,gxz:"Z15FuncionId",gxold:"O15FuncionId",gxvar:"A15FuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15FuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15FuncionId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("FUNCIONID",gx.O.A15FuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A15FuncionId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("FUNCIONID",".")},nac:function(){return!(0==this.AV7FuncionId)}};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_EspectaculoId)}};this.declareDomainHdlr(39,function(){});n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOFUNCION",fmt:0,gxz:"Z21PrecioFuncion",gxold:"O21PrecioFuncion",gxvar:"A21PrecioFuncion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z21PrecioFuncion=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRECIOFUNCION",gx.O.A21PrecioFuncion,0)},c2v:function(){this.val()!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRECIOFUNCION",".")},nac:gx.falseFn};n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONNAME",fmt:0,gxz:"Z22FuncionName",gxold:"O22FuncionName",gxvar:"A22FuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A22FuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z22FuncionName=n)},v2c:function(){gx.fn.setControlValue("FUNCIONNAME",gx.O.A22FuncionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A22FuncionName=this.val())},val:function(){return gx.fn.getControlValue("FUNCIONNAME")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"BTN_ENTER",grid:0,evt:"e13077_client",std:"ENTER"};n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"BTN_CANCEL",grid:0,evt:"e14077_client"};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"BTN_DELETE",grid:0,evt:"e20077_client",std:"DELETE"};n[59]={id:59,fld:"PROMPT_1",grid:7};this.A15FuncionId=0;this.Z15FuncionId=0;this.O15FuncionId=0;this.A1EspectaculoId=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.A21PrecioFuncion=0;this.Z21PrecioFuncion=0;this.O21PrecioFuncion=0;this.A22FuncionName="";this.Z22FuncionName="";this.O22FuncionName="";this.AV13Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV11Insert_EspectaculoId=0;this.AV14GXV1=0;this.AV12TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7FuncionId=0;this.AV10WebSession={};this.A15FuncionId=0;this.A1EspectaculoId=0;this.A21PrecioFuncion=0;this.A22FuncionName="";this.Gx_mode="";this.Events={e12072_client:["AFTER TRN",!0],e13077_client:["ENTER",!0],e14077_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7FuncionId",fld:"vFUNCIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7FuncionId",fld:"vFUNCIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_FUNCIONID=[[],[]];this.EvtParms.VALID_ESPECTACULOID=[[{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"}],[]];this.setPrompt("PROMPT_1",[39]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7FuncionId","vFUNCIONID",0,"int",4,0);this.setVCMap("AV11Insert_EspectaculoId","vINSERT_ESPECTACULOID",0,"int",4,0);this.setVCMap("AV13Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.funcion)})