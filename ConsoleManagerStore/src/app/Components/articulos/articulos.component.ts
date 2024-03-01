import { Component } from '@angular/core';
import { Articulos } from 'src/app/Interfaces/articulos.interface';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-articulos',
  templateUrl: './articulos.component.html',
  styleUrls: ['./articulos.component.scss']
})
export class ArticulosComponent {
  articulos:Articulos[];
  constructor(private service:StoreService){
    this.articulos =[];
  }
  ngOnInit():void{
    this.getArticulos();
  }

  getArticulos(){
    this.service.getArticulos().subscribe(data=>{
      return this.articulos = data;
    });
  }

  addArticuloToCart(articulo:Articulos){
    return this.service.addArticuloToCart(articulo);
  }
}
