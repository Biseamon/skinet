(self.webpackChunkclient=self.webpackChunkclient||[]).push([[422],{3422:(t,e,r)=>{"use strict";r.r(e),r.d(e,{AccountModule:()=>J});var n=r(1116),i=r(1462),o=r(7368),s=r(3230),l=r(8709),u=r(3722);let a=(()=>{class t{constructor(t,e,r){this.account=t,this.router=e,this.activatedRoute=r}ngOnInit(){this.returnUrl=this.activatedRoute.snapshot.queryParams.returnUrl||"/shop",this.createLoginForm()}createLoginForm(){this.loginForm=new i.cw({email:new i.NI(null,[i.kI.required,i.kI.pattern("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]),password:new i.NI(null,i.kI.required)})}onSubmit(){this.account.login(this.loginForm.value).subscribe(()=>{this.router.navigateByUrl(this.returnUrl),console.log("user logged in")},t=>{console.log(t)})}}return t.\u0275fac=function(e){return new(e||t)(o.Y36(s.B),o.Y36(l.F0),o.Y36(l.gz))},t.\u0275cmp=o.Xpm({type:t,selectors:[["app-login"]],decls:10,vars:5,consts:[[1,"d-flex","justify-content-center","mt-5"],[1,"col-3"],[3,"formGroup","ngSubmit"],[1,"text-center","mb-4"],[1,"h3","mb-3","font-weight-normal"],["formControlName","email",3,"label"],["formControlName","password",3,"label","type"],["type","submit",1,"btn","btn-lg","btn-primary","btn-block",3,"disabled"]],template:function(t,e){1&t&&(o.TgZ(0,"div",0),o.TgZ(1,"div",1),o.TgZ(2,"form",2),o.NdJ("ngSubmit",function(){return e.onSubmit()}),o.TgZ(3,"div",3),o.TgZ(4,"h1",4),o._uU(5,"Login"),o.qZA(),o.qZA(),o._UZ(6,"app-text-input",5),o._UZ(7,"app-text-input",6),o.TgZ(8,"button",7),o._uU(9,"Sign in"),o.qZA(),o.qZA(),o.qZA(),o.qZA()),2&t&&(o.xp6(2),o.Q6J("formGroup",e.loginForm),o.xp6(4),o.Q6J("label","Email Address"),o.xp6(1),o.Q6J("label","Password")("type","password"),o.xp6(1),o.Q6J("disabled",e.loginForm.invalid))},directives:[i._Y,i.JL,i.sg,u.t,i.JJ,i.u],styles:[""]}),t})();var c=r(8318),p=r(8569),m=r(8470);function g(t){return!(0,m.k)(t)&&t-parseFloat(t)+1>=0}var d=r(6163);function b(t){const{index:e,period:r,subscriber:n}=t;if(n.next(e),!n.closed){if(-1===r)return n.complete();t.index=e+1,this.schedule(t,r)}}var f=r(878),h=r(4689),Z=r(9996);function w(t,e){if(1&t&&(o.TgZ(0,"li"),o._uU(1),o.qZA()),2&t){const t=e.$implicit;o.xp6(1),o.hij(" ",t," ")}}function v(t,e){if(1&t&&(o.TgZ(0,"ul",10),o.YNc(1,w,2,1,"li",11),o.qZA()),2&t){const t=o.oxw();o.xp6(1),o.Q6J("ngForOf",t.errors)}}const x=[{path:"login",component:a},{path:"register",component:(()=>{class t{constructor(t,e,r){this.fb=t,this.accountService=e,this.router=r}ngOnInit(){this.createRegisterForm()}createRegisterForm(){this.registerForm=this.fb.group({displayName:[null,[i.kI.required]],email:[null,[i.kI.required,i.kI.pattern("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")],[this.validateEmailNotTaken()]],password:[null,[i.kI.required]]})}onSubmit(){this.accountService.register(this.registerForm.value).subscribe(t=>{this.router.navigateByUrl("/shop"),console.log(t)},t=>{console.log(t),this.errors=t.errors})}validateEmailNotTaken(){return t=>function(t=0,e,r){let n=-1;return g(e)?n=Number(e)<1?1:Number(e):(0,d.K)(e)&&(r=e),(0,d.K)(r)||(r=p.P),new c.y(e=>{const i=g(t)?t:+t-r.now();return r.schedule(b,i,{index:0,period:n,subscriber:e})})}(500).pipe((0,h.w)(()=>t.value?this.accountService.checkEmailExists(t.value).pipe((0,Z.U)(t=>t?{emailExists:!0}:null)):(0,f.of)(null)))}}return t.\u0275fac=function(e){return new(e||t)(o.Y36(i.qu),o.Y36(s.B),o.Y36(l.F0))},t.\u0275cmp=o.Xpm({type:t,selectors:[["app-register"]],decls:12,vars:6,consts:[[1,"d-flex","justify-content-center","mt-5"],[1,"col-3"],[3,"formGroup","ngSubmit"],[1,"text-center","mb-4"],[1,"h3","mb-3","font-weight-normal"],["formControlName","displayName",3,"label"],["formControlName","email",3,"label"],["formControlName","password",3,"label","type"],["class","text-danger list-unstyled",4,"ngIf"],["type","submit",1,"btn","btn-lg","btn-primary","btn-block"],[1,"text-danger","list-unstyled"],[4,"ngFor","ngForOf"]],template:function(t,e){1&t&&(o.TgZ(0,"div",0),o.TgZ(1,"div",1),o.TgZ(2,"form",2),o.NdJ("ngSubmit",function(){return e.onSubmit()}),o.TgZ(3,"div",3),o.TgZ(4,"h1",4),o._uU(5,"Login"),o.qZA(),o.qZA(),o._UZ(6,"app-text-input",5),o._UZ(7,"app-text-input",6),o._UZ(8,"app-text-input",7),o.YNc(9,v,2,1,"ul",8),o.TgZ(10,"button",9),o._uU(11,"Register"),o.qZA(),o.qZA(),o.qZA(),o.qZA()),2&t&&(o.xp6(2),o.Q6J("formGroup",e.registerForm),o.xp6(4),o.Q6J("label","Display Name"),o.xp6(1),o.Q6J("label","Email Address"),o.xp6(1),o.Q6J("label","Password")("type","password"),o.xp6(1),o.Q6J("ngIf",e.errors))},directives:[i._Y,i.JL,i.sg,u.t,i.JJ,i.u,n.O5,n.sg],styles:[""]}),t})()}];let y=(()=>{class t{}return t.\u0275fac=function(e){return new(e||t)},t.\u0275mod=o.oAB({type:t}),t.\u0275inj=o.cJS({imports:[[l.Bz.forChild(x)],l.Bz]}),t})();var q=r(5425);let J=(()=>{class t{}return t.\u0275fac=function(e){return new(e||t)},t.\u0275mod=o.oAB({type:t}),t.\u0275inj=o.cJS({imports:[[n.ez,y,q.m]]}),t})()}}]);