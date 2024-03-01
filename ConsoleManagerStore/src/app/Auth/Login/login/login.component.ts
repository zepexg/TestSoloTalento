import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  get usr(){
    return this.loginForm.controls.usr;
  }

  get pwd(){
    return this.loginForm.controls.pwd;
  }

  loginForm=this.formBuilder.group({
    usr:['', [Validators.required]],
    pwd:['', [Validators.required]]
  });

  constructor(private formBuilder:FormBuilder, private router:Router, private service:StoreService){

  }
  ngOnInit():void{

  }

  login(){
    if(this.loginForm.valid){
      this.service.login(this.usr.value??"0",this.pwd.value??"0").subscribe({
        next: (data) => {
          this.service.setUsuario(data);
          this.loginForm.reset();
          this.router.navigate(['home']);
        },
        error: (err) => {
          alert(err);
        },
        complete: () => {
          console.log("logueado");
        }
      });
    }else{
      alert("Error");
    }
  }
}
