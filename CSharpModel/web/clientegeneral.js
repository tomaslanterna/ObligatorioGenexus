gx.evt.autoSkip=!1;gx.define("clientegeneral",!0,function(n){this.ServerClass="clientegeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="clientegeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Clienteid=function(){return this.validCliEvt("Valid_Clienteid",0,function(){try{var n=gx.util.balloon.getNew("CLIENTEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Paisid=function(){return this.validCliEvt("Valid_Paisid",0,function(){try{var n=gx.util.balloon.getNew("PAISID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110f1_client=function(){return this.clearMessages(),this.call("cliente.aspx",["UPD",this.A9ClienteId],null,["Mode","ClienteId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120f1_client=function(){return this.clearMessages(),this.call("cliente.aspx",["DLT",this.A9ClienteId],null,["Mode","ClienteId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150f2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160f2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e110f1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e120f1_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Clienteid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",fmt:0,gxz:"Z9ClienteId",gxold:"O9ClienteId",gxvar:"A9ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9ClienteId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIENTEID",gx.O.A9ClienteId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9ClienteId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIENTEID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTENAME",fmt:0,gxz:"Z10ClienteName",gxold:"O10ClienteName",gxvar:"A10ClienteName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10ClienteName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10ClienteName=n)},v2c:function(){gx.fn.setControlValue("CLIENTENAME",gx.O.A10ClienteName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A10ClienteName=this.val())},val:function(){return gx.fn.getControlValue("CLIENTENAME")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Paisid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISID",fmt:0,gxz:"Z3PaisId",gxold:"O3PaisId",gxvar:"A3PaisId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A3PaisId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3PaisId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAISID",gx.O.A3PaisId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A3PaisId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAISID",".")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNAME",fmt:0,gxz:"Z6PaisName",gxold:"O6PaisName",gxvar:"A6PaisName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A6PaisName=n)},v2z:function(n){n!==undefined&&(gx.O.Z6PaisName=n)},v2c:function(){gx.fn.setControlValue("PAISNAME",gx.O.A6PaisName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A6PaisName=this.val())},val:function(){return gx.fn.getControlValue("PAISNAME")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});this.A9ClienteId=0;this.Z9ClienteId=0;this.O9ClienteId=0;this.A10ClienteName="";this.Z10ClienteName="";this.O10ClienteName="";this.A3PaisId=0;this.Z3PaisId=0;this.O3PaisId=0;this.A6PaisName="";this.Z6PaisName="";this.O6PaisName="";this.A9ClienteId=0;this.A10ClienteName="";this.A3PaisId=0;this.A6PaisName="";this.Events={e150f2_client:["ENTER",!0],e160f2_client:["CANCEL",!0],e110f1_client:["'DOUPDATE'",!1],e120f1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A9ClienteId",fld:"CLIENTEID",pic:"ZZZ9"},{av:"A3PaisId",fld:"PAISID",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A9ClienteId",fld:"CLIENTEID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A9ClienteId",fld:"CLIENTEID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_CLIENTEID=[[],[]];this.EvtParms.VALID_PAISID=[[],[]];this.Initialize()})