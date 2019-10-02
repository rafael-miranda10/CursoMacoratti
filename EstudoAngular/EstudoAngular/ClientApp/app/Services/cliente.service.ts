import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { ICliente } from '../Models/cliente.interface';

@Injectable()

export class ClienteService {

    constructor(private http: Http) { }

    //get
    getClientes() {
        return this.http.get('api/cliente')
            .map(data => <ICliente[]>data.json());  
    }
    // post - Inclur dados
    addCliente(Cliente: ICliente) {
        return this.http.post('api/cliente', Cliente);
    }

    // put - Alterar dados
    editCliente(Cliente: ICliente) {
        return this.http.put(`api/cliente/${Cliente.id}`, Cliente);
    }
    // delete - deletar dados
    deleteCliente(clienteId: number) {
        return this.http.delete(`api/cliente/${clienteId}`);
    }


}