gx.evt.autoSkip=!1;gx.define("espectaculolugarsectorwc",!0,function(n){var t,i;this.ServerClass="espectaculolugarsectorwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="espectaculolugarsectorwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6EspectaculoId=gx.fn.getIntegerValue("vESPECTACULOID",".");this.AV6EspectaculoId=gx.fn.getIntegerValue("vESPECTACULOID",".")};this.Valid_Lugarsectorid=function(){var n=gx.fn.currentGridRowImpl(12);return this.validCliEvt("Valid_Lugarsectorid",12,function(){try{if(gx.fn.currentGridRowImpl(12)===0)return!0;var n=gx.util.balloon.getNew("LUGARSECTORID",gx.fn.currentGridRowImpl(12));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lugarsectorcantidad=function(){var n=gx.fn.currentGridRowImpl(12);return this.validCliEvt("Valid_Lugarsectorcantidad",12,function(){try{if(gx.fn.currentGridRowImpl(12)===0)return!0;var n=gx.util.balloon.getNew("LUGARSECTORCANTIDAD",gx.fn.currentGridRowImpl(12));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lugarsectorvendidas=function(){var n=gx.fn.currentGridRowImpl(12);return this.validCliEvt("Valid_Lugarsectorvendidas",12,function(){try{if(gx.fn.currentGridRowImpl(12)===0)return!0;var n=gx.util.balloon.getNew("LUGARSECTORVENDIDAS",gx.fn.currentGridRowImpl(12));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){return this.validCliEvt("Valid_Espectaculoid",0,function(){try{var n=gx.util.balloon.getNew("ESPECTACULOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e131w2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e141w2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,13,14,15,16,17,18,19,20,21,22,23];this.GXLastCtrlId=23;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",12,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"espectaculolugarsectorwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(27,13,"LUGARSECTORID","Sector Id","","LugarSectorId","int",0,"px",4,4,"right",null,[],27,"LugarSectorId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(28,14,"LUGARSECTORNAME","Lugar Sector Name","","LugarSectorName","svchar",0,"px",40,40,"left",null,[],28,"LugarSectorName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(29,15,"LUGARSECTORCANTIDAD","Lugar Sector Cantidad","","LugarSectorCantidad","int",0,"px",4,4,"right",null,[],29,"LugarSectorCantidad",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addCheckBox(41,16,"LUGARSECTORESTADOSECTOR","Estado Sector","","LugarSectorEstadoSector","boolean","true","false",null,!0,!1,0,"px","WWColumn WWOptionalColumn");i.addSingleLineEdit(30,17,"LUGARSECTORPRECIO","Lugar Sector Precio","","LugarSectorPrecio","int",0,"px",4,4,"right",null,[],30,"LugarSectorPrecio",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(37,18,"LUGARSECTORVENDIDAS","Sector Vendidas","","LugarSectorVendidas","int",0,"px",4,4,"right",null,[],37,"LugarSectorVendidas",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(38,19,"LUGARSECTORDISPONIBLES","Sector Disponibles","","LugarSectorDisponibles","int",0,"px",4,4,"right",null,[],38,"LugarSectorDisponibles",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[13]={id:13,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Valid_Lugarsectorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORID",fmt:0,gxz:"Z27LugarSectorId",gxold:"O27LugarSectorId",gxvar:"A27LugarSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27LugarSectorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(12),gx.O.A27LugarSectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};t[14]={id:14,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORNAME",fmt:0,gxz:"Z28LugarSectorName",gxold:"O28LugarSectorName",gxvar:"A28LugarSectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A28LugarSectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z28LugarSectorName=n)},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORNAME",n||gx.fn.currentGridRowImpl(12),gx.O.A28LugarSectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A28LugarSectorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LUGARSECTORNAME",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn};t[15]={id:15,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Valid_Lugarsectorcantidad,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORCANTIDAD",fmt:0,gxz:"Z29LugarSectorCantidad",gxold:"O29LugarSectorCantidad",gxvar:"A29LugarSectorCantidad",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A29LugarSectorCantidad=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z29LugarSectorCantidad=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORCANTIDAD",n||gx.fn.currentGridRowImpl(12),gx.O.A29LugarSectorCantidad,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A29LugarSectorCantidad=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORCANTIDAD",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};t[16]={id:16,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORESTADOSECTOR",fmt:0,gxz:"Z41LugarSectorEstadoSector",gxold:"O41LugarSectorEstadoSector",gxvar:"A41LugarSectorEstadoSector",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A41LugarSectorEstadoSector=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z41LugarSectorEstadoSector=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("LUGARSECTORESTADOSECTOR",n||gx.fn.currentGridRowImpl(12),gx.O.A41LugarSectorEstadoSector,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A41LugarSectorEstadoSector=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("LUGARSECTORESTADOSECTOR",n||gx.fn.currentGridRowImpl(12))},nac:gx.falseFn,values:["true","false"]};t[17]={id:17,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORPRECIO",fmt:0,gxz:"Z30LugarSectorPrecio",gxold:"O30LugarSectorPrecio",gxvar:"A30LugarSectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30LugarSectorPrecio=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORPRECIO",n||gx.fn.currentGridRowImpl(12),gx.O.A30LugarSectorPrecio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORPRECIO",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};t[18]={id:18,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:this.Valid_Lugarsectorvendidas,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORVENDIDAS",fmt:0,gxz:"Z37LugarSectorVendidas",gxold:"O37LugarSectorVendidas",gxvar:"A37LugarSectorVendidas",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A37LugarSectorVendidas=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z37LugarSectorVendidas=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORVENDIDAS",n||gx.fn.currentGridRowImpl(12),gx.O.A37LugarSectorVendidas,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A37LugarSectorVendidas=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORVENDIDAS",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};t[19]={id:19,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:12,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORDISPONIBLES",fmt:0,gxz:"Z38LugarSectorDisponibles",gxold:"O38LugarSectorDisponibles",gxvar:"A38LugarSectorDisponibles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z38LugarSectorDisponibles=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORDISPONIBLES",n||gx.fn.currentGridRowImpl(12),gx.O.A38LugarSectorDisponibles,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORDISPONIBLES",n||gx.fn.currentGridRowImpl(12),".")},nac:gx.falseFn};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:gx.falseFn};this.declareDomainHdlr(23,function(){});this.Z27LugarSectorId=0;this.O27LugarSectorId=0;this.Z28LugarSectorName="";this.O28LugarSectorName="";this.Z29LugarSectorCantidad=0;this.O29LugarSectorCantidad=0;this.Z41LugarSectorEstadoSector=!1;this.O41LugarSectorEstadoSector=!1;this.Z30LugarSectorPrecio=0;this.O30LugarSectorPrecio=0;this.Z37LugarSectorVendidas=0;this.O37LugarSectorVendidas=0;this.Z38LugarSectorDisponibles=0;this.O38LugarSectorDisponibles=0;this.A1EspectaculoId=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.A1EspectaculoId=0;this.AV6EspectaculoId=0;this.A4LugarId=0;this.A27LugarSectorId=0;this.A28LugarSectorName="";this.A29LugarSectorCantidad=0;this.A41LugarSectorEstadoSector=!1;this.A30LugarSectorPrecio=0;this.A37LugarSectorVendidas=0;this.A38LugarSectorDisponibles=0;this.Events={e131w2_client:["ENTER",!0],e141w2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.EvtParms.VALID_LUGARSECTORID=[[],[]];this.EvtParms.VALID_LUGARSECTORCANTIDAD=[[],[]];this.EvtParms.VALID_LUGARSECTORVENDIDAS=[[],[]];this.setVCMap("AV6EspectaculoId","vESPECTACULOID",0,"int",4,0);this.setVCMap("AV6EspectaculoId","vESPECTACULOID",0,"int",4,0);this.setVCMap("AV6EspectaculoId","vESPECTACULOID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6EspectaculoId"});i.addRefreshingParm({rfrVar:"AV6EspectaculoId"});this.Initialize()})