import { Component } from '@angular/core';
import { StoreService } from 'src/app/Services/store.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  usr$ = this.service.usuario$;

  isShow: boolean;

  carrito$ = this.service.carrito$;

  constructor(private service:StoreService, private _router:Router){
    this.isShow = false;
  }
  
  ngOnInit():void{
  }

  showCarrito(){
    this.isShow = !this.isShow;
  }
  
  logout(){
    this.service.setUsuario({id:"",nombre:"",apellidos:"",direccion:""});
    this._router.navigate(['login']);
  }
}
