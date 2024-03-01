export interface Venta {
    clienteId: string,
    fecha: Date,
    detalle: DetalleVenta[]
}

export interface DetalleVenta{
    articuloId:string,
    cantidad:number,
    precio:number
}


/*

{
  "clienteId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "fecha": "2024-03-01T01:09:56.291Z",
  "detalle": [
    {
      "articuloId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "cantidad": 0,
      "precio": 0
    }
  ]
}

*/