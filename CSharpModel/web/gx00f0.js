gx.evt.autoSkip=!1;gx.define("gx00f0",!1,function(){var n,t;this.ServerClass="gx00f0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00f0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV11pEspectaculoId=gx.fn.getIntegerValue("vPESPECTACULOID",".")};this.Validv_Cespectaculofecha=function(){return this.validCliEvt("Validv_Cespectaculofecha",0,function(){try{var n=gx.util.balloon.getNew("vCESPECTACULOFECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8cEspectaculoFecha)===0||new gx.date.gxdate(this.AV8cEspectaculoFecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Espectaculo Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e161y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e111y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULOID","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULOID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOID","Visible")',ctrl:"vCESPECTACULOID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e121y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULONAMEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("ESPECTACULONAMEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCESPECTACULONAME","Visible",!0)):(gx.fn.setCtrlProperty("ESPECTACULONAMEFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCESPECTACULONAME","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULONAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULONAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULONAME","Visible")',ctrl:"vCESPECTACULONAME",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e131y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ESPECTACULOFECHAFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("ESPECTACULOFECHAFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("ESPECTACULOFECHAFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ESPECTACULOFECHAFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFECHAFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e141y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("LUGARIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("LUGARIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCLUGARID","Visible",!0)):(gx.fn.setCtrlProperty("LUGARIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCLUGARID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("LUGARIDFILTERCONTAINER","Class")',ctrl:"LUGARIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCLUGARID","Visible")',ctrl:"vCLUGARID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e151y1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TIPOESPECTACULOIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TIPOESPECTACULOIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTIPOESPECTACULOID","Visible",!0)):(gx.fn.setCtrlProperty("TIPOESPECTACULOIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTIPOESPECTACULOID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TIPOESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"TIPOESPECTACULOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTIPOESPECTACULOID","Visible")',ctrl:"vCTIPOESPECTACULOID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e191y2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e201y1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,65,66,67,68,69,70,71,72,73,74];this.GXLastCtrlId=74;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",64,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00f0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",65,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(1,66,"ESPECTACULOID","Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(2,67,"ESPECTACULONAME","Name","","EspectaculoName","svchar",0,"px",40,40,"left",null,[],2,"EspectaculoName",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(16,68,"ESPECTACULOFECHA","Fecha","","EspectaculoFecha","date",0,"px",8,8,"right",null,[],16,"EspectaculoFecha",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(4,69,"LUGARID","Lugar Id","","LugarId","int",0,"px",4,4,"right",null,[],4,"LugarId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(7,70,"TIPOESPECTACULOID","Tipo Espectaculo Id","","TipoEspectaculoId","int",0,"px",4,4,"right",null,[],7,"TipoEspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addBitmap(26,"ESPECTACULOIMAGEN",71,0,"px",17,"px",null,"","Imagen","ImageAttribute","WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"ESPECTACULOIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLESPECTACULOIDFILTER",format:1,grid:0,evt:"e111y1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOID",fmt:0,gxz:"ZV6cEspectaculoId",gxold:"OV6cEspectaculoId",gxvar:"AV6cEspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cEspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cEspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOID",gx.O.AV6cEspectaculoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cEspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCESPECTACULOID",".")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"ESPECTACULONAMEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLESPECTACULONAMEFILTER",format:1,grid:0,evt:"e121y1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULONAME",fmt:0,gxz:"ZV7cEspectaculoName",gxold:"OV7cEspectaculoName",gxvar:"AV7cEspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cEspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cEspectaculoName=n)},v2c:function(){gx.fn.setControlValue("vCESPECTACULONAME",gx.O.AV7cEspectaculoName,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cEspectaculoName=this.val())},val:function(){return gx.fn.getControlValue("vCESPECTACULONAME")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"ESPECTACULOFECHAFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLESPECTACULOFECHAFILTER",format:1,grid:0,evt:"e131y1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Cespectaculofecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCESPECTACULOFECHA",fmt:0,gxz:"ZV8cEspectaculoFecha",gxold:"OV8cEspectaculoFecha",gxvar:"AV8cEspectaculoFecha",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cEspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cEspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCESPECTACULOFECHA",gx.O.AV8cEspectaculoFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cEspectaculoFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCESPECTACULOFECHA")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"LUGARIDFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLLUGARIDFILTER",format:1,grid:0,evt:"e141y1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCLUGARID",fmt:0,gxz:"ZV9cLugarId",gxold:"OV9cLugarId",gxvar:"AV9cLugarId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cLugarId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cLugarId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCLUGARID",gx.O.AV9cLugarId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cLugarId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCLUGARID",".")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"TIPOESPECTACULOIDFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLTIPOESPECTACULOIDFILTER",format:1,grid:0,evt:"e151y1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTIPOESPECTACULOID",fmt:0,gxz:"ZV10cTipoEspectaculoId",gxold:"OV10cTipoEspectaculoId",gxvar:"AV10cTipoEspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cTipoEspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cTipoEspectaculoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCTIPOESPECTACULOID",gx.O.AV10cTipoEspectaculoId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cTipoEspectaculoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTIPOESPECTACULOID",".")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"GRIDTABLE",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"BTNTOGGLE",grid:0,evt:"e161y1_client"};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[65]={id:65,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",fmt:0,gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(64),gx.O.AV5LinkSelection,gx.O.AV15Linkselection_GXI)},c2v:function(n){gx.O.AV15Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(64))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(64))},gxvar_GXI:"AV15Linkselection_GXI",nac:gx.falseFn};n[66]={id:66,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(64),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[67]={id:67,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(64),gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(64))},nac:gx.falseFn};n[68]={id:68,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOFECHA",fmt:0,gxz:"Z16EspectaculoFecha",gxold:"O16EspectaculoFecha",gxvar:"A16EspectaculoFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z16EspectaculoFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(64),gx.O.A16EspectaculoFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16EspectaculoFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("ESPECTACULOFECHA",n||gx.fn.currentGridRowImpl(64))},nac:gx.falseFn};n[69]={id:69,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LUGARID",fmt:0,gxz:"Z4LugarId",gxold:"O4LugarId",gxvar:"A4LugarId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4LugarId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4LugarId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("LUGARID",n||gx.fn.currentGridRowImpl(64),gx.O.A4LugarId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4LugarId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("LUGARID",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[70]={id:70,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TIPOESPECTACULOID",fmt:0,gxz:"Z7TipoEspectaculoId",gxold:"O7TipoEspectaculoId",gxvar:"A7TipoEspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7TipoEspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7TipoEspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TIPOESPECTACULOID",n||gx.fn.currentGridRowImpl(64),gx.O.A7TipoEspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7TipoEspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TIPOESPECTACULOID",n||gx.fn.currentGridRowImpl(64),".")},nac:gx.falseFn};n[71]={id:71,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOIMAGEN",fmt:0,gxz:"Z26EspectaculoImagen",gxold:"O26EspectaculoImagen",gxvar:"A26EspectaculoImagen",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26EspectaculoImagen=n)},v2z:function(n){n!==undefined&&(gx.O.Z26EspectaculoImagen=n)},v2c:function(n){gx.fn.setGridMultimediaValue("ESPECTACULOIMAGEN",n||gx.fn.currentGridRowImpl(64),gx.O.A26EspectaculoImagen,gx.O.A40000EspectaculoImagen_GXI)},c2v:function(n){gx.O.A40000EspectaculoImagen_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A26EspectaculoImagen=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULOIMAGEN",n||gx.fn.currentGridRowImpl(64))},val_GXI:function(n){return gx.fn.getGridControlValue("ESPECTACULOIMAGEN_GXI",n||gx.fn.currentGridRowImpl(64))},gxvar_GXI:"A40000EspectaculoImagen_GXI",nac:gx.falseFn};n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"BTN_CANCEL",grid:0,evt:"e201y1_client"};this.AV6cEspectaculoId=0;this.ZV6cEspectaculoId=0;this.OV6cEspectaculoId=0;this.AV7cEspectaculoName="";this.ZV7cEspectaculoName="";this.OV7cEspectaculoName="";this.AV8cEspectaculoFecha=gx.date.nullDate();this.ZV8cEspectaculoFecha=gx.date.nullDate();this.OV8cEspectaculoFecha=gx.date.nullDate();this.AV9cLugarId=0;this.ZV9cLugarId=0;this.OV9cLugarId=0;this.AV10cTipoEspectaculoId=0;this.ZV10cTipoEspectaculoId=0;this.OV10cTipoEspectaculoId=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.Z2EspectaculoName="";this.O2EspectaculoName="";this.Z16EspectaculoFecha=gx.date.nullDate();this.O16EspectaculoFecha=gx.date.nullDate();this.Z4LugarId=0;this.O4LugarId=0;this.Z7TipoEspectaculoId=0;this.O7TipoEspectaculoId=0;this.Z26EspectaculoImagen="";this.O26EspectaculoImagen="";this.AV6cEspectaculoId=0;this.AV7cEspectaculoName="";this.AV8cEspectaculoFecha=gx.date.nullDate();this.AV9cLugarId=0;this.AV10cTipoEspectaculoId=0;this.A40000EspectaculoImagen_GXI="";this.AV11pEspectaculoId=0;this.AV5LinkSelection="";this.A1EspectaculoId=0;this.A2EspectaculoName="";this.A16EspectaculoFecha=gx.date.nullDate();this.A4LugarId=0;this.A7TipoEspectaculoId=0;this.A26EspectaculoImagen="";this.Events={e191y2_client:["ENTER",!0],e201y1_client:["CANCEL",!0],e161y1_client:["'TOGGLE'",!1],e111y1_client:["LBLESPECTACULOIDFILTER.CLICK",!1],e121y1_client:["LBLESPECTACULONAMEFILTER.CLICK",!1],e131y1_client:["LBLESPECTACULOFECHAFILTER.CLICK",!1],e141y1_client:["LBLLUGARIDFILTER.CLICK",!1],e151y1_client:["LBLTIPOESPECTACULOIDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV7cEspectaculoName",fld:"vCESPECTACULONAME",pic:""},{av:"AV8cEspectaculoFecha",fld:"vCESPECTACULOFECHA",pic:""},{av:"AV9cLugarId",fld:"vCLUGARID",pic:"ZZZ9"},{av:"AV10cTipoEspectaculoId",fld:"vCTIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLESPECTACULOIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"ESPECTACULOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULOID","Visible")',ctrl:"vCESPECTACULOID",prop:"Visible"}]];this.EvtParms["LBLESPECTACULONAMEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULONAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULONAMEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULONAMEFILTERCONTAINER","Class")',ctrl:"ESPECTACULONAMEFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCESPECTACULONAME","Visible")',ctrl:"vCESPECTACULONAME",prop:"Visible"}]];this.EvtParms["LBLESPECTACULOFECHAFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("ESPECTACULOFECHAFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFECHAFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ESPECTACULOFECHAFILTERCONTAINER","Class")',ctrl:"ESPECTACULOFECHAFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLLUGARIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("LUGARIDFILTERCONTAINER","Class")',ctrl:"LUGARIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("LUGARIDFILTERCONTAINER","Class")',ctrl:"LUGARIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCLUGARID","Visible")',ctrl:"vCLUGARID",prop:"Visible"}]];this.EvtParms["LBLTIPOESPECTACULOIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TIPOESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"TIPOESPECTACULOIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TIPOESPECTACULOIDFILTERCONTAINER","Class")',ctrl:"TIPOESPECTACULOIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTIPOESPECTACULOID","Visible")',ctrl:"vCTIPOESPECTACULOID",prop:"Visible"}]];this.EvtParms.ENTER=[[{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9",hsh:!0}],[{av:"AV11pEspectaculoId",fld:"vPESPECTACULOID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV7cEspectaculoName",fld:"vCESPECTACULONAME",pic:""},{av:"AV8cEspectaculoFecha",fld:"vCESPECTACULOFECHA",pic:""},{av:"AV9cLugarId",fld:"vCLUGARID",pic:"ZZZ9"},{av:"AV10cTipoEspectaculoId",fld:"vCTIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV7cEspectaculoName",fld:"vCESPECTACULONAME",pic:""},{av:"AV8cEspectaculoFecha",fld:"vCESPECTACULOFECHA",pic:""},{av:"AV9cLugarId",fld:"vCLUGARID",pic:"ZZZ9"},{av:"AV10cTipoEspectaculoId",fld:"vCTIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV7cEspectaculoName",fld:"vCESPECTACULONAME",pic:""},{av:"AV8cEspectaculoFecha",fld:"vCESPECTACULOFECHA",pic:""},{av:"AV9cLugarId",fld:"vCLUGARID",pic:"ZZZ9"},{av:"AV10cTipoEspectaculoId",fld:"vCTIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cEspectaculoId",fld:"vCESPECTACULOID",pic:"ZZZ9"},{av:"AV7cEspectaculoName",fld:"vCESPECTACULONAME",pic:""},{av:"AV8cEspectaculoFecha",fld:"vCESPECTACULOFECHA",pic:""},{av:"AV9cLugarId",fld:"vCLUGARID",pic:"ZZZ9"},{av:"AV10cTipoEspectaculoId",fld:"vCTIPOESPECTACULOID",pic:"ZZZ9"}],[]];this.EvtParms.VALIDV_CESPECTACULOFECHA=[[],[]];this.setVCMap("AV11pEspectaculoId","vPESPECTACULOID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00f0)})