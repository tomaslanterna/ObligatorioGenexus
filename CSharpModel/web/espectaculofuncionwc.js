gx.evt.autoSkip=!1;gx.define("espectaculofuncionwc",!0,function(n){var t,i;this.ServerClass="espectaculofuncionwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="espectaculofuncionwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6EspectaculoId=gx.fn.getIntegerValue("vESPECTACULOID",".");this.AV6EspectaculoId=gx.fn.getIntegerValue("vESPECTACULOID",".")};this.e110t2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e140t2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e150t2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29];this.GXLastCtrlId=29;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"espectaculofuncionwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(15,21,"FUNCIONID","Id","","FuncionId","int",0,"px",4,4,"right",null,[],15,"FuncionId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(21,22,"PRECIOFUNCION","Funcion","","PrecioFuncion","int",0,"px",4,4,"right",null,[],21,"PrecioFuncion",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");i.addSingleLineEdit(22,23,"FUNCIONNAME","Name","","FuncionName","char",0,"px",20,20,"left",null,[],22,"FuncionName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",24,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",25,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e110t2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONID",fmt:0,gxz:"Z15FuncionId",gxold:"O15FuncionId",gxvar:"A15FuncionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15FuncionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15FuncionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("FUNCIONID",n||gx.fn.currentGridRowImpl(20),gx.O.A15FuncionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15FuncionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("FUNCIONID",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOFUNCION",fmt:0,gxz:"Z21PrecioFuncion",gxold:"O21PrecioFuncion",gxvar:"A21PrecioFuncion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z21PrecioFuncion=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRECIOFUNCION",n||gx.fn.currentGridRowImpl(20),gx.O.A21PrecioFuncion,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A21PrecioFuncion=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRECIOFUNCION",n||gx.fn.currentGridRowImpl(20),".")},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FUNCIONNAME",fmt:0,gxz:"Z22FuncionName",gxold:"O22FuncionName",gxvar:"A22FuncionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A22FuncionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z22FuncionName=n)},v2c:function(n){gx.fn.setGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(20),gx.O.A22FuncionName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A22FuncionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("FUNCIONNAME",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ESPECTACULOID",gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ESPECTACULOID",".")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});this.Z15FuncionId=0;this.O15FuncionId=0;this.Z21PrecioFuncion=0;this.O21PrecioFuncion=0;this.Z22FuncionName="";this.O22FuncionName="";this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.A1EspectaculoId=0;this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.A1EspectaculoId=0;this.AV6EspectaculoId=0;this.A15FuncionId=0;this.A21PrecioFuncion=0;this.A22FuncionName="";this.AV13Update="";this.AV14Delete="";this.Events={e110t2_client:["'DOINSERT'",!0],e140t2_client:["ENTER",!0],e150t2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("PRECIOFUNCION","Link")',ctrl:"PRECIOFUNCION",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A15FuncionId",fld:"FUNCIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6EspectaculoId",fld:"vESPECTACULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.setVCMap("AV6EspectaculoId","vESPECTACULOID",0,"int",4,0);this.setVCMap("AV6EspectaculoId","vESPECTACULOID",0,"int",4,0);this.setVCMap("AV6EspectaculoId","vESPECTACULOID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6EspectaculoId"});i.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6EspectaculoId"});i.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})