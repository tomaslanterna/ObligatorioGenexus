gx.evt.autoSkip=!1;gx.define("wwespectaculo",!1,function(){var n,t;this.ServerClass="wwespectaculo";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwespectaculo.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Paisid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Paisid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("PAISID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Lugarid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Lugarid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("LUGARID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Tipoespectaculoid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Tipoespectaculoid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("TIPOESPECTACULOID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e110p2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e150p2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e160p2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,26,27,28,29,30,31,32,33,34,35,36];this.GXLastCtrlId=36;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwespectaculo",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(1,26,"ESPECTACULOID","Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(2,27,"ESPECTACULONAME","Name","","EspectaculoName","svchar",0,"px",40,40,"left",null,[],2,"EspectaculoName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(3,28,"PAISID","Pais Id","","PaisId","int",0,"px",4,4,"right",null,[],3,"PaisId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(6,29,"PAISNAME","Pais Name","","PaisName","svchar",0,"px",40,40,"left",null,[],6,"PaisName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(4,30,"LUGARID","Lugar Id","","LugarId","int",0,"px",4,4,"right",null,[],4,"LugarId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(5,31,"LUGARNAME","Lugar Name","","LugarName","svchar",0,"px",40,40,"left",null,[],5,"LugarName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(7,32,"TIPOESPECTACULOID","Tipo Espectaculo Id","","TipoEspectaculoId","int",0,"px",4,4,"right",null,[],7,"TipoEspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(8,33,"TIPOESPECTACULONAME","Tipo Espectaculo Name","","TipoEspectaculoName","svchar",0,"px",40,40,"left",null,[],8,"TipoEspectaculoName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addBitmap(26,"ESPECTACULOIMAGEN",34,0,"px",17,"px",null,"","Imagen","ImageAttribute","WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",35,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",36,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e110p2_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vESPECTACULONAME",fmt:0,gxz:"ZV11EspectaculoName",gxold:"OV11EspectaculoName",gxvar:"AV11EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11EspectaculoName=n)},v2c:function(){gx.fn.setControlValue("vESPECTACULONAME",gx.O.AV11EspectaculoName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11EspectaculoName=this.val())},val:function(){return gx.fn.getControlValue("vESPECTACULONAME")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDCELL",grid:0};n[19]={id:19,fld:"GRIDTABLE",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(25),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(25),gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Paisid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISID",fmt:0,gxz:"Z3PaisId",gxold:"O3PaisId",gxvar:"A3PaisId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3PaisId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z3PaisId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PAISID",n||gx.fn.currentGridRowImpl(25),gx.O.A3PaisId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3PaisId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PAISID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNAME",fmt:0,gxz:"Z6PaisName",gxold:"O6PaisName",gxvar:"A6PaisName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A6PaisName=n)},v2z:function(n){n!==undefined&&(gx.O.Z6PaisName=n)},v2c:function(n){gx.fn.setGridControlValue("PAISNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A6PaisName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6PaisName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PAISNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Lugarid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARID",fmt:0,gxz:"Z4LugarId",gxold:"O4LugarId",gxvar:"A4LugarId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4LugarId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4LugarId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARID",n||gx.fn.currentGridRowImpl(25),gx.O.A4LugarId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4LugarId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARNAME",fmt:0,gxz:"Z5LugarName",gxold:"O5LugarName",gxvar:"A5LugarName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A5LugarName=n)},v2z:function(n){n!==undefined&&(gx.O.Z5LugarName=n)},v2c:function(n){gx.fn.setGridControlValue("LUGARNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A5LugarName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A5LugarName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("LUGARNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Tipoespectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULOID",fmt:0,gxz:"Z7TipoEspectaculoId",gxold:"O7TipoEspectaculoId",gxvar:"A7TipoEspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7TipoEspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7TipoEspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TIPOESPECTACULOID",n||gx.fn.currentGridRowImpl(25),gx.O.A7TipoEspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7TipoEspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TIPOESPECTACULOID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULONAME",fmt:0,gxz:"Z8TipoEspectaculoName",gxold:"O8TipoEspectaculoName",gxvar:"A8TipoEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8TipoEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8TipoEspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(25),gx.O.A8TipoEspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8TipoEspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[34]={id:34,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOIMAGEN",fmt:0,gxz:"Z26EspectaculoImagen",gxold:"O26EspectaculoImagen",gxvar:"A26EspectaculoImagen",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26EspectaculoImagen=n)},v2z:function(n){n!==undefined&&(gx.O.Z26EspectaculoImagen=n)},v2c:function(n){gx.fn.setGridMultimediaValue("ESPECTACULOIMAGEN",n||gx.fn.currentGridRowImpl(25),gx.O.A26EspectaculoImagen,gx.O.A40000EspectaculoImagen_GXI)},c2v:function(n){gx.O.A40000EspectaculoImagen_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A26EspectaculoImagen=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOIMAGEN",n||gx.fn.currentGridRowImpl(25))},val_GXI:function(n){return gx.fn.getGridControlValue("ESPECTACULOIMAGEN_GXI",n||gx.fn.currentGridRowImpl(25))},gxvar_GXI:"A40000EspectaculoImagen_GXI",nac:gx.falseFn};n[35]={id:35,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[36]={id:36,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};this.AV11EspectaculoName="";this.ZV11EspectaculoName="";this.OV11EspectaculoName="";this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.Z2EspectaculoName="";this.O2EspectaculoName="";this.Z3PaisId=0;this.O3PaisId=0;this.Z6PaisName="";this.O6PaisName="";this.Z4LugarId=0;this.O4LugarId=0;this.Z5LugarName="";this.O5LugarName="";this.Z7TipoEspectaculoId=0;this.O7TipoEspectaculoId=0;this.Z8TipoEspectaculoName="";this.O8TipoEspectaculoName="";this.Z26EspectaculoImagen="";this.O26EspectaculoImagen="";this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11EspectaculoName="";this.A40000EspectaculoImagen_GXI="";this.A1EspectaculoId=0;this.A2EspectaculoName="";this.A3PaisId=0;this.A6PaisName="";this.A4LugarId=0;this.A5LugarName="";this.A7TipoEspectaculoId=0;this.A8TipoEspectaculoName="";this.A26EspectaculoImagen="";this.AV12Update="";this.AV13Delete="";this.Events={e110p2_client:["'DOINSERT'",!0],e150p2_client:["ENTER",!0],e160p2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11EspectaculoName",fld:"vESPECTACULONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9",hsh:!0},{av:"A3PaisId",fld:"PAISID",pic:"ZZZ9"},{av:"A4LugarId",fld:"LUGARID",pic:"ZZZ9"},{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("ESPECTACULONAME","Link")',ctrl:"ESPECTACULONAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("PAISNAME","Link")',ctrl:"PAISNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("LUGARNAME","Link")',ctrl:"LUGARNAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("TIPOESPECTACULONAME","Link")',ctrl:"TIPOESPECTACULONAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11EspectaculoName",fld:"vESPECTACULONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11EspectaculoName",fld:"vESPECTACULONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11EspectaculoName",fld:"vESPECTACULONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11EspectaculoName",fld:"vESPECTACULONAME",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.VALID_PAISID=[[],[]];this.EvtParms.VALID_LUGARID=[[],[]];this.EvtParms.VALID_TIPOESPECTACULOID=[[],[]];t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwespectaculo)})