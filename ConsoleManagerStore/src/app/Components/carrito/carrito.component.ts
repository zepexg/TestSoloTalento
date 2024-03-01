import { Component } from '@angular/core';
import { Articulos } from 'src/app/Interfaces/articulos.interface';
import { Venta, DetalleVenta } from 'src/app/Interfaces/venta.interface';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.scss']
})
export class CarritoComponent {

  usr$ = this.service.usuario$;
  carrito$ = this.service.carrito$;

  constructor(private service:StoreService){}
  ngOnInit():void{

  }

  generarVenta(){
    let detalleVenta:DetalleVenta[]=[];
    this.usr$.subscribe({
      next: data => {
        let venta:Venta = {clienteId:data.id, fecha:new Date(Date.now()), detalle:detalleVenta};
    
        this.carrito$.subscribe(articulos => {
          articulos.map(articulo => {
            let {id, cantidad, precio} = articulo;
            detalleVenta.push({articuloId:id, cantidad:cantidad, precio:precio})
          });
        })
    
        this.service.saveArticulos(venta).subscribe(x => {
          this.service.clearCart();
        });
      }
    });
  }

  setCurrenciFormat(monto:number){
    return new Intl.NumberFormat('es-MX', { style: 'currency', currency: 'MXN'}).format(monto)
  }

  delArticuloFromCart(articulo:Articulos){
    this.service.delArticuloFromCart(articulo);
  }

  updateCantidad(articulo:Articulos, operacion:string){
    this.service.updateCantidad(articulo,operacion);
  }

  calculaTotal(){
    let total = 0;
    this.carrito$.subscribe(articulo => {
      articulo.map( x => {
        total += x.cantidad * x.precio;
      })
    })
    return this.setCurrenciFormat(total);
  }
}
