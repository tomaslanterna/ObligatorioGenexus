gx.evt.autoSkip=!1;gx.define("wpespectaculostipo",!1,function(){var t,i,n;this.ServerClass="wpespectaculostipo";this.PackageName="GeneXus.Programs";this.ServerFullClass="wpespectaculostipo.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.e13242_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14242_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8,9,10,11,12,13,14,15,16,17,18,20,21,22,23];this.GXLastCtrlId=23;this.Grid2Container=new gx.grid.grid(this,3,"WbpLvl3",19,"Grid2","Grid2","Grid2Container",this.CmpContext,this.IsMasterPage,"wpespectaculostipo",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.Grid2Container;i.addSingleLineEdit(2,20,"ESPECTACULONAME","Espectaculos:","","EspectaculoName","svchar",0,"px",40,40,"left",null,[],2,"EspectaculoName",!0,0,!1,!1,"Attribute",1,"");this.Grid2Container.emptyText="";this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",6,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"wpespectaculostipo",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Nueva fila",!1,!1,!1,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);n=this.Grid1Container;n.startDiv(7,"Grid1table","0px","0px");n.startDiv(8,"","0px","0px");n.startDiv(9,"","0px","0px");n.startDiv(10,"","0px","0px");n.addLabel();n.startDiv(11,"","0px","0px");n.addSingleLineEdit(8,12,"TIPOESPECTACULONAME","","","TipoEspectaculoName","svchar",40,"chr",40,40,"left",null,[],8,"TipoEspectaculoName",!0,0,!1,!1,"Attribute",1,"");n.endDiv();n.endDiv();n.endDiv();n.startDiv(13,"","0px","0px");n.startDiv(14,"","0px","0px");n.addLabel();n.startDiv(15,"","0px","0px");n.addSingleLineEdit("Cantidadespectaculos",16,"vCANTIDADESPECTACULOS","","","CantidadEspectaculos","int",4,"chr",4,4,"right",null,[],"Cantidadespectaculos","CantidadEspectaculos",!0,0,!1,!1,"Attribute",1,"");n.endDiv();n.endDiv();n.endDiv();n.endDiv();n.startDiv(17,"","0px","0px");n.startDiv(18,"","0px","0px");n.addGrid(this.Grid2Container);n.endDiv();n.endDiv();n.startDiv(21,"","0px","0px");n.startDiv(22,"","0px","0px");n.startDiv(23,"Table1","0px","0px");n.endDiv();n.endDiv();n.endDiv();n.endDiv();this.Grid1Container.emptyText="";this.setGrid(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[7]={id:7,fld:"GRID1TABLE",grid:6};t[8]={id:8,fld:"",grid:6};t[9]={id:9,fld:"",grid:6};t[10]={id:10,fld:"",grid:6};t[11]={id:11,fld:"",grid:6};t[12]={id:12,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:6,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULONAME",fmt:0,gxz:"Z8TipoEspectaculoName",gxold:"O8TipoEspectaculoName",gxvar:"A8TipoEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8TipoEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8TipoEspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(6),gx.O.A8TipoEspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8TipoEspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TIPOESPECTACULONAME",n||gx.fn.currentGridRowImpl(6))},nac:gx.falseFn};t[13]={id:13,fld:"",grid:6};t[14]={id:14,fld:"",grid:6};t[15]={id:15,fld:"",grid:6};t[16]={id:16,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:6,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCANTIDADESPECTACULOS",fmt:0,gxz:"ZV5CantidadEspectaculos",gxold:"OV5CantidadEspectaculos",gxvar:"AV5CantidadEspectaculos",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5CantidadEspectaculos=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5CantidadEspectaculos=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vCANTIDADESPECTACULOS",n||gx.fn.currentGridRowImpl(6),gx.O.AV5CantidadEspectaculos,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV5CantidadEspectaculos=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vCANTIDADESPECTACULOS",n||gx.fn.currentGridRowImpl(6),".")},nac:gx.falseFn};t[17]={id:17,fld:"",grid:6};t[18]={id:18,fld:"",grid:6};t[20]={id:20,lvl:3,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:19,gxgrid:this.Grid2Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(19),gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(19))},nac:gx.falseFn};t[21]={id:21,fld:"",grid:6};t[22]={id:22,fld:"",grid:6};t[23]={id:23,fld:"TABLE1",grid:6};this.Z8TipoEspectaculoName="";this.O8TipoEspectaculoName="";this.ZV5CantidadEspectaculos=0;this.OV5CantidadEspectaculos=0;this.Z2EspectaculoName="";this.O2EspectaculoName="";this.A7TipoEspectaculoId=0;this.A40000GXC1=0;this.A8TipoEspectaculoName="";this.AV5CantidadEspectaculos=0;this.A2EspectaculoName="";this.Events={e13242_client:["ENTER",!0],e14242_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"GRID2_nFirstRecordOnPage"},{av:"GRID2_nEOF"},{av:"A7TipoEspectaculoId",fld:"TIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["GRID1.LOAD"]=[[],[{av:"AV5CantidadEspectaculos",fld:"vCANTIDADESPECTACULOS",pic:"ZZZ9"},{av:"A40000GXC1",fld:"GXC1",pic:"999999999"}]];this.EvtParms.ENTER=[[],[]];i.addRefreshingVar({rfrVar:"A7TipoEspectaculoId"});i.addRefreshingParm({rfrVar:"A7TipoEspectaculoId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wpespectaculostipo)})