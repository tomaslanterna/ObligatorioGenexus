gx.evt.autoSkip=!1;gx.define("espectaculos",!1,function(){this.ServerClass="espectaculos";this.PackageName="GeneXus.Programs";this.ServerFullClass="espectaculos.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Validv_Fechaespectaculo=function(){return this.validCliEvt("Validv_Fechaespectaculo",0,function(){try{var n=gx.util.balloon.getNew("vFECHAESPECTACULO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV5FechaEspectaculo)===0||new gx.date.gxdate(this.AV5FechaEspectaculo).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Fecha Espectaculo fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11232_client=function(){return this.executeServerEvent("'IMPRIMIRESPECTACULOS'",!1,null,!1,!1)};this.e12232_client=function(){return this.executeServerEvent("'IMPRIMIRESPECTACULOSPORFECHA'",!1,null,!1,!1)};this.e14232_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e15232_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13];this.GXLastCtrlId=13;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Fechaespectaculo,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFECHAESPECTACULO",fmt:0,gxz:"ZV5FechaEspectaculo",gxold:"OV5FechaEspectaculo",gxvar:"AV5FechaEspectaculo",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[8],ip:[8],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5FechaEspectaculo=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5FechaEspectaculo=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vFECHAESPECTACULO",gx.O.AV5FechaEspectaculo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV5FechaEspectaculo=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vFECHAESPECTACULO")},nac:gx.falseFn};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"IMPRIMIRESPECTACULOSPORFECHA",grid:0,evt:"e12232_client"};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"IMPRIMIRESPECTACULOS",grid:0,evt:"e11232_client"};this.AV5FechaEspectaculo=gx.date.nullDate();this.ZV5FechaEspectaculo=gx.date.nullDate();this.OV5FechaEspectaculo=gx.date.nullDate();this.AV5FechaEspectaculo=gx.date.nullDate();this.Events={e11232_client:["'IMPRIMIRESPECTACULOS'",!0],e12232_client:["'IMPRIMIRESPECTACULOSPORFECHA'",!0],e14232_client:["ENTER",!0],e15232_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'IMPRIMIRESPECTACULOS'"]=[[],[]];this.EvtParms["'IMPRIMIRESPECTACULOSPORFECHA'"]=[[{av:"AV5FechaEspectaculo",fld:"vFECHAESPECTACULO",pic:""}],[{av:"AV5FechaEspectaculo",fld:"vFECHAESPECTACULO",pic:""}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_FECHAESPECTACULO=[[],[]];this.Initialize()});gx.wi(function(){gx.createParentObj(this.espectaculos)})