gx.evt.autoSkip=!1;gx.define("clienteentradawc",!0,function(n){var t,i;this.ServerClass="clienteentradawc";this.PackageName="GeneXus.Programs";this.ServerFullClass="clienteentradawc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A29LugarSectorCantidad=gx.fn.getIntegerValue("LUGARSECTORCANTIDAD",".");this.A37LugarSectorVendidas=gx.fn.getIntegerValue("LUGARSECTORVENDIDAS",".");this.A4LugarId=gx.fn.getIntegerValue("LUGARID",".");this.A7TipoEspectaculoId=gx.fn.getIntegerValue("TIPOESPECTACULOID",".");this.AV6ClienteId=gx.fn.getIntegerValue("vCLIENTEID",".");this.AV6ClienteId=gx.fn.getIntegerValue("vCLIENTEID",".")};this.Valid_Espectaculoid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Espectaculoid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("ESPECTACULOID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lugarsectorid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Lugarsectorid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("LUGARSECTORID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculofuncionid=function(){var n=gx.fn.currentGridRowImpl(20);return this.validCliEvt("Valid_Espectaculofuncionid",20,function(){try{if(gx.fn.currentGridRowImpl(20)===0)return!0;var n=gx.util.balloon.getNew("ESPECTACULOFUNCIONID",gx.fn.currentGridRowImpl(20));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110h2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e140h2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e150h2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41];this.GXLastCtrlId=41;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"clienteentradawc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(23,21,"ENTRADAID","Id","","EntradaId","int",0,"px",4,4,"right",null,[],23,"EntradaId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(5,22,"LUGARNAME","Lugar Name","","LugarName","svchar",0,"px",40,40,"left",null,[],5,"LugarName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(42,23,"ENTRADAFECHA","Fecha","","EntradaFecha","date",0,"px",8,8,"right",null,[],42,"EntradaFecha",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");i.addSingleLineEdit(1,24,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(2,25,"ESPECTACULONAME","Espectaculo Name","","EspectaculoName","svchar",0,"px",40,40,"left",null,[],2,"EspectaculoName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(16,26,"ESPECTACULOFECHA","Espectaculo Fecha","","EspectaculoFecha","date",0,"px",8,8,"right",null,[],16,"EspectaculoFecha",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(27,27,"LUGARSECTORID","Lugar Sector Id","","LugarSectorId","int",0,"px",4,4,"right",null,[],27,"LugarSectorId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(38,28,"LUGARSECTORDISPONIBLES","Lugar Sector Disponibles","","LugarSectorDisponibles","int",0,"px",4,4,"right",null,[],38,"LugarSectorDisponibles",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(8,29,"TIPOESPECTACULONAME","Tipo Espectaculo Name","","TipoEspectaculoName","svchar",0,"px",40,40,"left",null,[],8,"TipoEspectaculoName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(47,30,"ESPECTACULOFUNCIONID","Espectaculo Funcion Id","","EspectaculoFuncionId","int",0,"px",4,4,"right",null,[],47,"EspectaculoFuncionId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(48,31,"ESPECTACULOFUNCIONNAME","Espectaculo Funcion Name","","EspectaculoFuncionName","svchar",0,"px",40,40,"left",null,[],48,"EspectaculoFuncionName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(50,32,"ESPECTACULOPAISNAME","Pais Name","","EspectaculoPaisName","svchar",0,"px",40,40,"left",null,[],50,"EspectaculoPaisName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(28,33,"LUGARSECTORNAME","Lugar Sector Name","","LugarSectorName","svchar",0,"px",40,40,"left",null,[],28,"LugarSectorName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(30,34,"LUGARSECTORPRECIO","Lugar Sector Precio","","LugarSectorPrecio","int",0,"px",4,4,"right",null,[],30,"LugarSectorPrecio",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addBitmap(26,"ESPECTACULOIMAGEN",35,0,"px",17,"px",null,"","Espectaculo Imagen","ImageAttribute","WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",36,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",37,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e110h2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAID",fmt:0,gxz:"Z23EntradaId",gxold:"O23EntradaId",gxvar:"A23EntradaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A23EntradaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23EntradaId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ENTRADAID",n||gx.fn.currentGridRowImpl(20),gx.O.A23EntradaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A23EntradaId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ENTRADAID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARNAME",fmt:0,gxz:"Z5LugarName",gxold:"O5LugarName",gxvar:"A5LugarName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5LugarName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5LugarName=n)},v2c:function(n){gx.fn.setGridControlValue("LUGARNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A5LugarName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5LugarName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LUGARNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAFECHA",fmt:0,gxz:"Z42EntradaFecha",gxold:"O42EntradaFecha",gxvar:"A42EntradaFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A42EntradaFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z42EntradaFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ENTRADAFECHA",n||gx.fn.currentGridRowImpl(20),gx.O.A42EntradaFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A42EntradaFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ENTRADAFECHA",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(20),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(20),gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[26]={id:26,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z16EspectaculoFecha",gxold:"O16EspectaculoFecha",gxvar:"A16EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(20),gx.O.A16EspectaculoFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[27]={id:27,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Lugarsectorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORID",fmt:0,gxz:"Z27LugarSectorId",gxold:"O27LugarSectorId",gxvar:"A27LugarSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27LugarSectorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(20),gx.O.A27LugarSectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORDISPONIBLES",fmt:0,gxz:"Z38LugarSectorDisponibles",gxold:"O38LugarSectorDisponibles",gxvar:"A38LugarSectorDisponibles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z38LugarSectorDisponibles=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORDISPONIBLES",n||gx.fn.currentGridRowImpl(20),gx.O.A38LugarSectorDisponibles,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORDISPONIBLES",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULONAME",fmt:0,gxz:"Z8TipoEspectaculoName",gxold:"O8TipoEspectaculoName",gxvar:"A8TipoEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8TipoEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8TipoEspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(20),gx.O.A8TipoEspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8TipoEspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[30]={id:30,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:this.Valid_Espectaculofuncionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFUNCIONID",fmt:0,gxz:"Z47EspectaculoFuncionId",gxold:"O47EspectaculoFuncionId",gxvar:"A47EspectaculoFuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A47EspectaculoFuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z47EspectaculoFuncionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFUNCIONID",n||gx.fn.currentGridRowImpl(20),gx.O.A47EspectaculoFuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A47EspectaculoFuncionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOFUNCIONID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[31]={id:31,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFUNCIONNAME",fmt:0,gxz:"Z48EspectaculoFuncionName",gxold:"O48EspectaculoFuncionName",gxvar:"A48EspectaculoFuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A48EspectaculoFuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z48EspectaculoFuncionName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFUNCIONNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A48EspectaculoFuncionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A48EspectaculoFuncionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOFUNCIONNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[32]={id:32,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOPAISNAME",fmt:0,gxz:"Z50EspectaculoPaisName",gxold:"O50EspectaculoPaisName",gxvar:"A50EspectaculoPaisName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A50EspectaculoPaisName=n)},v2z:function(n){n!==undefined&&(gx.O.Z50EspectaculoPaisName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOPAISNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A50EspectaculoPaisName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A50EspectaculoPaisName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOPAISNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[33]={id:33,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORNAME",fmt:0,gxz:"Z28LugarSectorName",gxold:"O28LugarSectorName",gxvar:"A28LugarSectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A28LugarSectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z28LugarSectorName=n)},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A28LugarSectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A28LugarSectorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LUGARSECTORNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[34]={id:34,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORPRECIO",fmt:0,gxz:"Z30LugarSectorPrecio",gxold:"O30LugarSectorPrecio",gxvar:"A30LugarSectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30LugarSectorPrecio=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORPRECIO",n||gx.fn.currentGridRowImpl(20),gx.O.A30LugarSectorPrecio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORPRECIO",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[35]={id:35,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOIMAGEN",fmt:0,gxz:"Z26EspectaculoImagen",gxold:"O26EspectaculoImagen",gxvar:"A26EspectaculoImagen",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26EspectaculoImagen=n)},v2z:function(n){n!==undefined&&(gx.O.Z26EspectaculoImagen=n)},v2c:function(n){gx.fn.setGridMultimediaValue("ESPECTACULOIMAGEN",n||gx.fn.currentGridRowImpl(20),gx.O.A26EspectaculoImagen,gx.O.A40000EspectaculoImagen_GXI)},c2v:function(n){gx.O.A40000EspectaculoImagen_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A26EspectaculoImagen=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOIMAGEN",n||gx.fn.currentGridRowImpl(20))},val_GXI:function(n){return gx.fn.getGridControlValue("ESPECTACULOIMAGEN_GXI",n||gx.fn.currentGridRowImpl(20))},gxvar_GXI:"A40000EspectaculoImagen_GXI",nac:gx.falseFn};t[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[37]={id:37,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[38]={id:38,fld:"",grid:0};t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",fmt:0,gxz:"Z9ClienteId",gxold:"O9ClienteId",gxvar:"A9ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9ClienteId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIENTEID",gx.O.A9ClienteId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A9ClienteId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIENTEID",".")},nac:gx.falseFn};this.declareDomainHdlr(41,function(){});this.Z23EntradaId=0;this.O23EntradaId=0;this.Z5LugarName="";this.O5LugarName="";this.Z42EntradaFecha=gx.date.nullDate();this.O42EntradaFecha=gx.date.nullDate();this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.Z2EspectaculoName="";this.O2EspectaculoName="";this.Z16EspectaculoFecha=gx.date.nullDate();this.O16EspectaculoFecha=gx.date.nullDate();this.Z27LugarSectorId=0;this.O27LugarSectorId=0;this.Z38LugarSectorDisponibles=0;this.O38LugarSectorDisponibles=0;this.Z8TipoEspectaculoName="";this.O8TipoEspectaculoName="";this.Z47EspectaculoFuncionId=0;this.O47EspectaculoFuncionId=0;this.Z48EspectaculoFuncionName="";this.O48EspectaculoFuncionName="";this.Z50EspectaculoPaisName="";this.O50EspectaculoPaisName="";this.Z28LugarSectorName="";this.O28LugarSectorName="";this.Z30LugarSectorPrecio=0;this.O30LugarSectorPrecio=0;this.Z26EspectaculoImagen="";this.O26EspectaculoImagen="";this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.A9ClienteId=0;this.Z9ClienteId=0;this.O9ClienteId=0;this.A9ClienteId=0;this.A40000EspectaculoImagen_GXI="";this.AV6ClienteId=0;this.A4LugarId=0;this.A7TipoEspectaculoId=0;this.A29LugarSectorCantidad=0;this.A37LugarSectorVendidas=0;this.A23EntradaId=0;this.A5LugarName="";this.A42EntradaFecha=gx.date.nullDate();this.A1EspectaculoId=0;this.A2EspectaculoName="";this.A16EspectaculoFecha=gx.date.nullDate();this.A27LugarSectorId=0;this.A38LugarSectorDisponibles=0;this.A8TipoEspectaculoName="";this.A47EspectaculoFuncionId=0;this.A48EspectaculoFuncionName="";this.A50EspectaculoPaisName="";this.A28LugarSectorName="";this.A30LugarSectorPrecio=0;this.A26EspectaculoImagen="";this.AV13Update="";this.AV14Delete="";this.Events={e110h2_client:["'DOINSERT'",!0],e140h2_client:["ENTER",!0],e150h2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ClienteId",fld:"vCLIENTEID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9",hsh:!0},{av:"A4LugarId",fld:"LUGARID",pic:"ZZZ9"},{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"},{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("LUGARNAME","Link")',ctrl:"LUGARNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("ENTRADAFECHA","Link")',ctrl:"ENTRADAFECHA",prop:"Link"},{av:'gx.fn.getCtrlProperty("ESPECTACULONAME","Link")',ctrl:"ESPECTACULONAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("TIPOESPECTACULONAME","Link")',ctrl:"TIPOESPECTACULONAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ClienteId",fld:"vCLIENTEID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ClienteId",fld:"vCLIENTEID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ClienteId",fld:"vCLIENTEID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ClienteId",fld:"vCLIENTEID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.EvtParms.VALID_LUGARSECTORID=[[],[]];this.EvtParms.VALID_ESPECTACULOFUNCIONID=[[],[]];this.setVCMap("A29LugarSectorCantidad","LUGARSECTORCANTIDAD",0,"int",4,0);this.setVCMap("A37LugarSectorVendidas","LUGARSECTORVENDIDAS",0,"int",4,0);this.setVCMap("A4LugarId","LUGARID",0,"int",4,0);this.setVCMap("A7TipoEspectaculoId","TIPOESPECTACULOID",0,"int",4,0);this.setVCMap("AV6ClienteId","vCLIENTEID",0,"int",4,0);this.setVCMap("AV6ClienteId","vCLIENTEID",0,"int",4,0);this.setVCMap("AV6ClienteId","vCLIENTEID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6ClienteId"});i.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6ClienteId"});i.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})