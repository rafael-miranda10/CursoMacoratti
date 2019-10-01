import { Component, OnInit, OnDestroy } from '@angular/core';
import { ClienteService } from '../../Services/cliente.service';
import { ICliente } from '../../Models/cliente.interface';


@Component({
    selector: 'cliente',
    templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {

    //cliente
    cliente: ICliente = <ICliente>{};
    clientes: ICliente[] = [];

    constructor(private _clienteService: ClienteService) { }

    private getClientes() {

        this._clienteService.getClientes().subscribe(
            data => this.clientes = data,
            error => alert(error),
            () => console.log(this.cliente)
        );
    }

    ngOnInit() {
        this.getClientes();
    }
}