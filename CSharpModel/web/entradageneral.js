gx.evt.autoSkip=!1;gx.define("entradageneral",!0,function(n){this.ServerClass="entradageneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="entradageneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A29LugarSectorCantidad=gx.fn.getIntegerValue("LUGARSECTORCANTIDAD",".");this.A37LugarSectorVendidas=gx.fn.getIntegerValue("LUGARSECTORVENDIDAS",".")};this.Valid_Entradaid=function(){return this.validCliEvt("Valid_Entradaid",0,function(){try{var n=gx.util.balloon.getNew("ENTRADAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Clienteid=function(){return this.validCliEvt("Valid_Clienteid",0,function(){try{var n=gx.util.balloon.getNew("CLIENTEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){return this.validCliEvt("Valid_Espectaculoid",0,function(){try{var n=gx.util.balloon.getNew("ESPECTACULOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lugarsectorid=function(){return this.validCliEvt("Valid_Lugarsectorid",0,function(){try{var n=gx.util.balloon.getNew("LUGARSECTORID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110n1_client=function(){return this.clearMessages(),this.call("entrada.aspx",["UPD",this.A23EntradaId],null,["Mode","EntradaId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120n1_client=function(){return this.clearMessages(),this.call("entrada.aspx",["DLT",this.A23EntradaId],null,["Mode","EntradaId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150n2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e160n2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93];this.GXLastCtrlId=93;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e110n1_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e120n1_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Entradaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAID",fmt:0,gxz:"Z23EntradaId",gxold:"O23EntradaId",gxvar:"A23EntradaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A23EntradaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23EntradaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ENTRADAID",gx.O.A23EntradaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A23EntradaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ENTRADAID",".")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAFECHA",fmt:0,gxz:"Z42EntradaFecha",gxold:"O42EntradaFecha",gxvar:"A42EntradaFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A42EntradaFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z42EntradaFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("ENTRADAFECHA",gx.O.A42EntradaFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A42EntradaFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("ENTRADAFECHA")},nac:gx.falseFn};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Clienteid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",fmt:0,gxz:"Z9ClienteId",gxold:"O9ClienteId",gxvar:"A9ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9ClienteId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIENTEID",gx.O.A9ClienteId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9ClienteId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIENTEID",".")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTENAME",fmt:0,gxz:"Z10ClienteName",gxold:"O10ClienteName",gxvar:"A10ClienteName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A10ClienteName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10ClienteName=n)},v2c:function(){gx.fn.setControlValue("CLIENTENAME",gx.O.A10ClienteName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A10ClienteName=this.val())},val:function(){return gx.fn.getControlValue("CLIENTENAME")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(){gx.fn.setControlValue("ESPECTACULONAME",gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A2EspectaculoName=this.val())},val:function(){return gx.fn.getControlValue("ESPECTACULONAME")},nac:gx.falseFn};this.declareDomainHdlr(43,function(){});t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z16EspectaculoFecha",gxold:"O16EspectaculoFecha",gxvar:"A16EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOFECHA",gx.O.A16EspectaculoFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("ESPECTACULOFECHA")},nac:gx.falseFn};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNAME",fmt:0,gxz:"Z6PaisName",gxold:"O6PaisName",gxvar:"A6PaisName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A6PaisName=n)},v2z:function(n){n!==undefined&&(gx.O.Z6PaisName=n)},v2c:function(){gx.fn.setControlValue("PAISNAME",gx.O.A6PaisName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A6PaisName=this.val())},val:function(){return gx.fn.getControlValue("PAISNAME")},nac:gx.falseFn};this.declareDomainHdlr(53,function(){});t[54]={id:54,fld:"",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,fld:"",grid:0};t[58]={id:58,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARNAME",fmt:0,gxz:"Z5LugarName",gxold:"O5LugarName",gxvar:"A5LugarName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5LugarName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5LugarName=n)},v2c:function(){gx.fn.setControlValue("LUGARNAME",gx.O.A5LugarName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5LugarName=this.val())},val:function(){return gx.fn.getControlValue("LUGARNAME")},nac:gx.falseFn};this.declareDomainHdlr(58,function(){});t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"",grid:0};t[61]={id:61,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Lugarsectorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORID",fmt:0,gxz:"Z27LugarSectorId",gxold:"O27LugarSectorId",gxvar:"A27LugarSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27LugarSectorId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LUGARSECTORID",gx.O.A27LugarSectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LUGARSECTORID",".")},nac:gx.falseFn};this.declareDomainHdlr(63,function(){});t[64]={id:64,fld:"",grid:0};t[65]={id:65,fld:"",grid:0};t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[68]={id:68,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORNAME",fmt:0,gxz:"Z28LugarSectorName",gxold:"O28LugarSectorName",gxvar:"A28LugarSectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A28LugarSectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z28LugarSectorName=n)},v2c:function(){gx.fn.setControlValue("LUGARSECTORNAME",gx.O.A28LugarSectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A28LugarSectorName=this.val())},val:function(){return gx.fn.getControlValue("LUGARSECTORNAME")},nac:gx.falseFn};this.declareDomainHdlr(68,function(){});t[69]={id:69,fld:"",grid:0};t[70]={id:70,fld:"",grid:0};t[71]={id:71,fld:"",grid:0};t[72]={id:72,fld:"",grid:0};t[73]={id:73,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORPRECIO",fmt:0,gxz:"Z30LugarSectorPrecio",gxold:"O30LugarSectorPrecio",gxvar:"A30LugarSectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30LugarSectorPrecio=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LUGARSECTORPRECIO",gx.O.A30LugarSectorPrecio,0)},c2v:function(){this.val()!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LUGARSECTORPRECIO",".")},nac:gx.falseFn};t[74]={id:74,fld:"",grid:0};t[75]={id:75,fld:"",grid:0};t[76]={id:76,fld:"",grid:0};t[77]={id:77,fld:"",grid:0};t[78]={id:78,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORDISPONIBLES",fmt:0,gxz:"Z38LugarSectorDisponibles",gxold:"O38LugarSectorDisponibles",gxvar:"A38LugarSectorDisponibles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z38LugarSectorDisponibles=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("LUGARSECTORDISPONIBLES",gx.O.A38LugarSectorDisponibles,0)},c2v:function(){this.val()!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("LUGARSECTORDISPONIBLES",".")},nac:gx.falseFn};t[79]={id:79,fld:"",grid:0};t[80]={id:80,fld:"",grid:0};t[81]={id:81,fld:"",grid:0};t[82]={id:82,fld:"",grid:0};t[83]={id:83,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULONAME",fmt:0,gxz:"Z8TipoEspectaculoName",gxold:"O8TipoEspectaculoName",gxvar:"A8TipoEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8TipoEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8TipoEspectaculoName=n)},v2c:function(){gx.fn.setControlValue("TIPOESPECTACULONAME",gx.O.A8TipoEspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8TipoEspectaculoName=this.val())},val:function(){return gx.fn.getControlValue("TIPOESPECTACULONAME")},nac:gx.falseFn};this.declareDomainHdlr(83,function(){});t[84]={id:84,fld:"",grid:0};t[85]={id:85,fld:"",grid:0};t[86]={id:86,fld:"",grid:0};t[87]={id:87,fld:"",grid:0};t[88]={id:88,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAPAISORIGENID",fmt:0,gxz:"Z43EntradaPaisOrigenId",gxold:"O43EntradaPaisOrigenId",gxvar:"A43EntradaPaisOrigenId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A43EntradaPaisOrigenId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z43EntradaPaisOrigenId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ENTRADAPAISORIGENID",gx.O.A43EntradaPaisOrigenId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A43EntradaPaisOrigenId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ENTRADAPAISORIGENID",".")},nac:gx.falseFn};this.declareDomainHdlr(88,function(){});t[89]={id:89,fld:"",grid:0};t[90]={id:90,fld:"",grid:0};t[91]={id:91,fld:"",grid:0};t[92]={id:92,fld:"",grid:0};t[93]={id:93,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAPAISORIGENNAME",fmt:0,gxz:"Z44EntradaPaisOrigenName",gxold:"O44EntradaPaisOrigenName",gxvar:"A44EntradaPaisOrigenName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A44EntradaPaisOrigenName=n)},v2z:function(n){n!==undefined&&(gx.O.Z44EntradaPaisOrigenName=n)},v2c:function(){gx.fn.setControlValue("ENTRADAPAISORIGENNAME",gx.O.A44EntradaPaisOrigenName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A44EntradaPaisOrigenName=this.val())},val:function(){return gx.fn.getControlValue("ENTRADAPAISORIGENNAME")},nac:gx.falseFn};this.declareDomainHdlr(93,function(){});this.A23EntradaId=0;this.Z23EntradaId=0;this.O23EntradaId=0;this.A42EntradaFecha=gx.date.nullDate();this.Z42EntradaFecha=gx.date.nullDate();this.O42EntradaFecha=gx.date.nullDate();this.A9ClienteId=0;this.Z9ClienteId=0;this.O9ClienteId=0;this.A10ClienteName="";this.Z10ClienteName="";this.O10ClienteName="";this.A1EspectaculoId=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.A2EspectaculoName="";this.Z2EspectaculoName="";this.O2EspectaculoName="";this.A16EspectaculoFecha=gx.date.nullDate();this.Z16EspectaculoFecha=gx.date.nullDate();this.O16EspectaculoFecha=gx.date.nullDate();this.A6PaisName="";this.Z6PaisName="";this.O6PaisName="";this.A5LugarName="";this.Z5LugarName="";this.O5LugarName="";this.A27LugarSectorId=0;this.Z27LugarSectorId=0;this.O27LugarSectorId=0;this.A28LugarSectorName="";this.Z28LugarSectorName="";this.O28LugarSectorName="";this.A30LugarSectorPrecio=0;this.Z30LugarSectorPrecio=0;this.O30LugarSectorPrecio=0;this.A38LugarSectorDisponibles=0;this.Z38LugarSectorDisponibles=0;this.O38LugarSectorDisponibles=0;this.A8TipoEspectaculoName="";this.Z8TipoEspectaculoName="";this.O8TipoEspectaculoName="";this.A43EntradaPaisOrigenId=0;this.Z43EntradaPaisOrigenId=0;this.O43EntradaPaisOrigenId=0;this.A44EntradaPaisOrigenName="";this.Z44EntradaPaisOrigenName="";this.O44EntradaPaisOrigenName="";this.A23EntradaId=0;this.A42EntradaFecha=gx.date.nullDate();this.A9ClienteId=0;this.A10ClienteName="";this.A1EspectaculoId=0;this.A2EspectaculoName="";this.A16EspectaculoFecha=gx.date.nullDate();this.A6PaisName="";this.A5LugarName="";this.A27LugarSectorId=0;this.A28LugarSectorName="";this.A30LugarSectorPrecio=0;this.A38LugarSectorDisponibles=0;this.A8TipoEspectaculoName="";this.A43EntradaPaisOrigenId=0;this.A44EntradaPaisOrigenName="";this.A3PaisId=0;this.A4LugarId=0;this.A7TipoEspectaculoId=0;this.A29LugarSectorCantidad=0;this.A37LugarSectorVendidas=0;this.Events={e150n2_client:["ENTER",!0],e160n2_client:["CANCEL",!0],e110n1_client:["'DOUPDATE'",!1],e120n1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9"},{av:"A9ClienteId",fld:"CLIENTEID",pic:"ZZZ9"},{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_ENTRADAID=[[],[]];this.EvtParms.VALID_CLIENTEID=[[],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.EvtParms.VALID_LUGARSECTORID=[[],[]];this.setVCMap("A29LugarSectorCantidad","LUGARSECTORCANTIDAD",0,"int",4,0);this.setVCMap("A37LugarSectorVendidas","LUGARSECTORVENDIDAS",0,"int",4,0);this.Initialize()})