import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Articulos } from 'src/app/Interfaces/articulos.interface';
import { StoreService } from 'src/app/Services/store.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent {
  usr$ = this.service.usuario$;
  articulos:Articulos[];
  constructor(private service:StoreService, private router:Router){
    this.articulos = [];
  }
  ngOnInit(): void{
    this.service.getArticulos().subscribe(data=>{
      this.articulos = data;
    });
    this.usr$.subscribe({
      next: data => {
        if(data.id === "") this.router.navigate(["login"]);
      }
    });
  }
}
