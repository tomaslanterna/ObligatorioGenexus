gx.evt.autoSkip=!1;gx.define("wwentrada",!1,function(){var n,t;this.ServerClass="wwentrada";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwentrada.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A40LugarSectorCantidadAsientos=gx.fn.getIntegerValue("LUGARSECTORCANTIDADASIENTOS",".");this.A37LugarSectorVendidas=gx.fn.getIntegerValue("LUGARSECTORVENDIDAS",".");this.A3PaisId=gx.fn.getIntegerValue("PAISID",".");this.A4LugarId=gx.fn.getIntegerValue("LUGARID",".");this.A7TipoEspectaculoId=gx.fn.getIntegerValue("TIPOESPECTACULOID",".")};this.Validv_Entradafecha=function(){return this.validCliEvt("Validv_Entradafecha",0,function(){try{var n=gx.util.balloon.getNew("vENTRADAFECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV16EntradaFecha)===0||new gx.date.gxdate(this.AV16EntradaFecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Entrada Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Clienteid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Clienteid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("CLIENTEID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Espectaculoid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("ESPECTACULOID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Funcionid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Funcionid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("FUNCIONID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lugarsectorid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Lugarsectorid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("LUGARSECTORID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110m2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150m2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160m2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45];this.GXLastCtrlId=45;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwentrada",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(23,26,"ENTRADAID","Id","","EntradaId","int",0,"px",4,4,"right",null,[],23,"EntradaId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(42,27,"ENTRADAFECHA","Fecha","","EntradaFecha","date",0,"px",8,8,"right",null,[],42,"EntradaFecha",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(9,28,"CLIENTEID","Cliente Id","","ClienteId","int",0,"px",4,4,"right",null,[],9,"ClienteId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(10,29,"CLIENTENAME","Cliente Name","","ClienteName","svchar",0,"px",40,40,"left",null,[],10,"ClienteName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(1,30,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(2,31,"ESPECTACULONAME","Espectaculo Name","","EspectaculoName","svchar",0,"px",40,40,"left",null,[],2,"EspectaculoName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(16,32,"ESPECTACULOFECHA","Espectaculo Fecha","","EspectaculoFecha","date",0,"px",8,8,"right",null,[],16,"EspectaculoFecha",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(15,33,"FUNCIONID","Funcion Id","","FuncionId","int",0,"px",4,4,"right",null,[],15,"FuncionId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(22,34,"FUNCIONNAME","Funcion Name","","FuncionName","svchar",0,"px",40,40,"left",null,[],22,"FuncionName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(6,35,"PAISNAME","Pais Name","","PaisName","svchar",0,"px",40,40,"left",null,[],6,"PaisName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(5,36,"LUGARNAME","Lugar Name","","LugarName","svchar",0,"px",40,40,"left",null,[],5,"LugarName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(27,37,"LUGARSECTORID","Sector Id","","LugarSectorId","int",0,"px",4,4,"right",null,[],27,"LugarSectorId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(28,38,"LUGARSECTORNAME","Lugar Sector Name","","LugarSectorName","svchar",0,"px",40,40,"left",null,[],28,"LugarSectorName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(30,39,"LUGARSECTORPRECIO","Lugar Sector Precio","","LugarSectorPrecio","int",0,"px",4,4,"right",null,[],30,"LugarSectorPrecio",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(38,40,"LUGARSECTORDISPONIBLES","Lugar Sector Disponibles","","LugarSectorDisponibles","int",0,"px",4,4,"right",null,[],38,"LugarSectorDisponibles",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(8,41,"TIPOESPECTACULONAME","Tipo Espectaculo Name","","TipoEspectaculoName","svchar",0,"px",40,40,"left",null,[],8,"TipoEspectaculoName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(43,42,"ENTRADAPAISORIGENID","Origen Id","","EntradaPaisOrigenId","int",0,"px",4,4,"right",null,[],43,"EntradaPaisOrigenId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(44,43,"ENTRADAPAISORIGENNAME","Origen Name","","EntradaPaisOrigenName","svchar",0,"px",40,40,"left",null,[],44,"EntradaPaisOrigenName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",44,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",45,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110m2_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Entradafecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vENTRADAFECHA",fmt:0,gxz:"ZV16EntradaFecha",gxold:"OV16EntradaFecha",gxvar:"AV16EntradaFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[16],ip:[16],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV16EntradaFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV16EntradaFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vENTRADAFECHA",gx.O.AV16EntradaFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV16EntradaFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vENTRADAFECHA")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDCELL",grid:0};n[19]={id:19,fld:"GRIDTABLE",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAID",fmt:0,gxz:"Z23EntradaId",gxold:"O23EntradaId",gxvar:"A23EntradaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A23EntradaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z23EntradaId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ENTRADAID",n||gx.fn.currentGridRowImpl(25),gx.O.A23EntradaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A23EntradaId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ENTRADAID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAFECHA",fmt:0,gxz:"Z42EntradaFecha",gxold:"O42EntradaFecha",gxvar:"A42EntradaFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A42EntradaFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z42EntradaFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ENTRADAFECHA",n||gx.fn.currentGridRowImpl(25),gx.O.A42EntradaFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A42EntradaFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ENTRADAFECHA",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Clienteid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",fmt:0,gxz:"Z9ClienteId",gxold:"O9ClienteId",gxvar:"A9ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A9ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z9ClienteId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("CLIENTEID",n||gx.fn.currentGridRowImpl(25),gx.O.A9ClienteId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A9ClienteId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("CLIENTEID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTENAME",fmt:0,gxz:"Z10ClienteName",gxold:"O10ClienteName",gxvar:"A10ClienteName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A10ClienteName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10ClienteName=n)},v2c:function(n){gx.fn.setGridControlValue("CLIENTENAME",n||gx.fn.currentGridRowImpl(25),gx.O.A10ClienteName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10ClienteName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CLIENTENAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(25),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(25),gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z16EspectaculoFecha",gxold:"O16EspectaculoFecha",gxvar:"A16EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(25),gx.O.A16EspectaculoFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Funcionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONID",fmt:0,gxz:"Z15FuncionId",gxold:"O15FuncionId",gxvar:"A15FuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15FuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15FuncionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("FUNCIONID",n||gx.fn.currentGridRowImpl(25),gx.O.A15FuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15FuncionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("FUNCIONID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONNAME",fmt:0,gxz:"Z22FuncionName",gxold:"O22FuncionName",gxvar:"A22FuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A22FuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z22FuncionName=n)},v2c:function(n){gx.fn.setGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A22FuncionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A22FuncionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[35]={id:35,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNAME",fmt:0,gxz:"Z6PaisName",gxold:"O6PaisName",gxvar:"A6PaisName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A6PaisName=n)},v2z:function(n){n!==undefined&&(gx.O.Z6PaisName=n)},v2c:function(n){gx.fn.setGridControlValue("PAISNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A6PaisName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6PaisName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PAISNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARNAME",fmt:0,gxz:"Z5LugarName",gxold:"O5LugarName",gxvar:"A5LugarName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5LugarName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5LugarName=n)},v2c:function(n){gx.fn.setGridControlValue("LUGARNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A5LugarName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5LugarName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LUGARNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[37]={id:37,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Lugarsectorid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORID",fmt:0,gxz:"Z27LugarSectorId",gxold:"O27LugarSectorId",gxvar:"A27LugarSectorId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27LugarSectorId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(25),gx.O.A27LugarSectorId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27LugarSectorId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[38]={id:38,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORNAME",fmt:0,gxz:"Z28LugarSectorName",gxold:"O28LugarSectorName",gxvar:"A28LugarSectorName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A28LugarSectorName=n)},v2z:function(n){n!==undefined&&(gx.O.Z28LugarSectorName=n)},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A28LugarSectorName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A28LugarSectorName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LUGARSECTORNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[39]={id:39,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORPRECIO",fmt:0,gxz:"Z30LugarSectorPrecio",gxold:"O30LugarSectorPrecio",gxvar:"A30LugarSectorPrecio",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z30LugarSectorPrecio=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORPRECIO",n||gx.fn.currentGridRowImpl(25),gx.O.A30LugarSectorPrecio,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30LugarSectorPrecio=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORPRECIO",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[40]={id:40,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARSECTORDISPONIBLES",fmt:0,gxz:"Z38LugarSectorDisponibles",gxold:"O38LugarSectorDisponibles",gxvar:"A38LugarSectorDisponibles",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z38LugarSectorDisponibles=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARSECTORDISPONIBLES",n||gx.fn.currentGridRowImpl(25),gx.O.A38LugarSectorDisponibles,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A38LugarSectorDisponibles=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARSECTORDISPONIBLES",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[41]={id:41,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULONAME",fmt:0,gxz:"Z8TipoEspectaculoName",gxold:"O8TipoEspectaculoName",gxvar:"A8TipoEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8TipoEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8TipoEspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(25),gx.O.A8TipoEspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8TipoEspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[42]={id:42,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAPAISORIGENID",fmt:0,gxz:"Z43EntradaPaisOrigenId",gxold:"O43EntradaPaisOrigenId",gxvar:"A43EntradaPaisOrigenId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A43EntradaPaisOrigenId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z43EntradaPaisOrigenId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ENTRADAPAISORIGENID",n||gx.fn.currentGridRowImpl(25),gx.O.A43EntradaPaisOrigenId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A43EntradaPaisOrigenId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ENTRADAPAISORIGENID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[43]={id:43,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ENTRADAPAISORIGENNAME",fmt:0,gxz:"Z44EntradaPaisOrigenName",gxold:"O44EntradaPaisOrigenName",gxvar:"A44EntradaPaisOrigenName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A44EntradaPaisOrigenName=n)},v2z:function(n){n!==undefined&&(gx.O.Z44EntradaPaisOrigenName=n)},v2c:function(n){gx.fn.setGridControlValue("ENTRADAPAISORIGENNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A44EntradaPaisOrigenName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A44EntradaPaisOrigenName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ENTRADAPAISORIGENNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[44]={id:44,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[45]={id:45,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};this.AV16EntradaFecha=gx.date.nullDate();this.ZV16EntradaFecha=gx.date.nullDate();this.OV16EntradaFecha=gx.date.nullDate();this.Z23EntradaId=0;this.O23EntradaId=0;this.Z42EntradaFecha=gx.date.nullDate();this.O42EntradaFecha=gx.date.nullDate();this.Z9ClienteId=0;this.O9ClienteId=0;this.Z10ClienteName="";this.O10ClienteName="";this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.Z2EspectaculoName="";this.O2EspectaculoName="";this.Z16EspectaculoFecha=gx.date.nullDate();this.O16EspectaculoFecha=gx.date.nullDate();this.Z15FuncionId=0;this.O15FuncionId=0;this.Z22FuncionName="";this.O22FuncionName="";this.Z6PaisName="";this.O6PaisName="";this.Z5LugarName="";this.O5LugarName="";this.Z27LugarSectorId=0;this.O27LugarSectorId=0;this.Z28LugarSectorName="";this.O28LugarSectorName="";this.Z30LugarSectorPrecio=0;this.O30LugarSectorPrecio=0;this.Z38LugarSectorDisponibles=0;this.O38LugarSectorDisponibles=0;this.Z8TipoEspectaculoName="";this.O8TipoEspectaculoName="";this.Z43EntradaPaisOrigenId=0;this.O43EntradaPaisOrigenId=0;this.Z44EntradaPaisOrigenName="";this.O44EntradaPaisOrigenName="";this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV16EntradaFecha=gx.date.nullDate();this.A3PaisId=0;this.A4LugarId=0;this.A7TipoEspectaculoId=0;this.A37LugarSectorVendidas=0;this.A40LugarSectorCantidadAsientos=0;this.A23EntradaId=0;this.A42EntradaFecha=gx.date.nullDate();this.A9ClienteId=0;this.A10ClienteName="";this.A1EspectaculoId=0;this.A2EspectaculoName="";this.A16EspectaculoFecha=gx.date.nullDate();this.A15FuncionId=0;this.A22FuncionName="";this.A6PaisName="";this.A5LugarName="";this.A27LugarSectorId=0;this.A28LugarSectorName="";this.A30LugarSectorPrecio=0;this.A38LugarSectorDisponibles=0;this.A8TipoEspectaculoName="";this.A43EntradaPaisOrigenId=0;this.A44EntradaPaisOrigenName="";this.AV12Update="";this.AV13Delete="";this.Events={e110m2_client:["'DOINSERT'",!0],e150m2_client:["ENTER",!0],e160m2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16EntradaFecha",fld:"vENTRADAFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9",hsh:!0},{av:"A9ClienteId",fld:"CLIENTEID",pic:"ZZZ9"},{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"},{av:"A3PaisId",fld:"PAISID",pic:"ZZZ9"},{av:"A4LugarId",fld:"LUGARID",pic:"ZZZ9"},{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("ENTRADAFECHA","Link")',ctrl:"ENTRADAFECHA",prop:"Link"},{av:'gx.fn.getCtrlProperty("CLIENTENAME","Link")',ctrl:"CLIENTENAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("ESPECTACULONAME","Link")',ctrl:"ESPECTACULONAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("PAISNAME","Link")',ctrl:"PAISNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("LUGARNAME","Link")',ctrl:"LUGARNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("TIPOESPECTACULONAME","Link")',ctrl:"TIPOESPECTACULONAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A23EntradaId",fld:"ENTRADAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16EntradaFecha",fld:"vENTRADAFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16EntradaFecha",fld:"vENTRADAFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16EntradaFecha",fld:"vENTRADAFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV16EntradaFecha",fld:"vENTRADAFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.VALIDV_ENTRADAFECHA=[[],[]];this.EvtParms.VALID_CLIENTEID=[[],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.EvtParms.VALID_FUNCIONID=[[],[]];this.EvtParms.VALID_LUGARSECTORID=[[],[]];this.setVCMap("A40LugarSectorCantidadAsientos","LUGARSECTORCANTIDADASIENTOS",0,"int",4,0);this.setVCMap("A37LugarSectorVendidas","LUGARSECTORVENDIDAS",0,"int",4,0);this.setVCMap("A3PaisId","PAISID",0,"int",4,0);this.setVCMap("A4LugarId","LUGARID",0,"int",4,0);this.setVCMap("A7TipoEspectaculoId","TIPOESPECTACULOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwentrada)})