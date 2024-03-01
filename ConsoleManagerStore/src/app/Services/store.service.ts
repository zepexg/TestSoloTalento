import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Articulos } from '../Interfaces/articulos.interface';
import { Venta } from '../Interfaces/venta.interface';
import { Cliente } from '../Interfaces/cliente.interface';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  baseUrl:string = 'https://localhost:44336/api/';

  private articuloList: Articulos[];
  private usuarioLogueado:Cliente;
  private carrito = new BehaviorSubject<Articulos[]>([]);
  carrito$ = this.carrito.asObservable();
  private usuario = new BehaviorSubject<Cliente>({id:"",nombre:"",apellidos:"",direccion:""});
  usuario$ = this.usuario.asObservable();

  currentUserLoginOn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private httpClient:HttpClient) {
    this.articuloList = [];
    this.usuarioLogueado = {id:"",nombre:"",apellidos:"",direccion:""};
  }

  getArticulos = (): Observable<Articulos[]> =>{
    const response = this.httpClient.get<Articulos[]>(`${this.baseUrl}Articulos`);
    return response;
  }

  saveArticulos = (venta:Venta) =>{
    const response = this.httpClient.post<Venta>(`${this.baseUrl}Ventas`, venta);
    return response;
  }

  login = (usr:string, pwd:string) =>{
    const response = this.httpClient.get<Cliente>(`${this.baseUrl}Clientes/login?Usuario=${usr}&Pasword=${pwd}`);
    return response;
  }

  clearCart(){
    this.articuloList = [];
    this.carrito.next(this.articuloList);
  }

  setUsuario(usuario:Cliente){
    this.usuarioLogueado = usuario;
    this.usuario.next(this.usuarioLogueado);
  }

  addArticuloToCart(articulo: Articulos){
    const articuloExistente = this.articuloList.find( x => {
      return x.id == articulo.id;
    });
    if(articuloExistente) articuloExistente.cantidad += 1;
    else {
      articulo.cantidad = 1;
      this.articuloList.push(articulo);
    }
    this.carrito.next(this.articuloList);
  }

  delArticuloFromCart(articulo: Articulos){
    this.articuloList = this.articuloList.filter(x => x.id !== articulo.id)
    this.carrito.next(this.articuloList);
  }

  updateCantidad(articulo: Articulos, operacion:string){
    const articuloExistente = this.articuloList.find( x => {
      return x.id == articulo.id;
    });
    if(articuloExistente){
      if(operacion == "incremento"){
        articuloExistente.cantidad += 1;
      }else{
        articuloExistente.cantidad -= 1;
        if(articuloExistente.cantidad <= 0) this.articuloList = this.articuloList.filter(x => x.id !== articulo.id)
      }
    }
    this.carrito.next(this.articuloList);
  }
}
