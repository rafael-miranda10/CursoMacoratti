import { Injectable } from '@angular/core';
import { Http, Response } from "@angular/http";
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";
import { IFornecedor } from "../Models/fornecedor.interface";

@Injectable()
export class FornecedorService {

    constructor(private http: Http) { }

    addFornecedor(fornecedor: IFornecedor) {
        return this.http.post("/api/fornecedor", fornecedor);
    }

    editFornecedor(fornecedor: IFornecedor) {
        return this.http.put(`/api/fornecedor/${fornecedor.fornecedorId}`, fornecedor);
    }

    deleteFornecedor(fornecedorId: number) {
        return this.http.delete(`/api/fornecedor/${fornecedorId}`);
    }

    getFornecedores() {
        return this.http.get("/api/fornecedor").map(data => <IFornecedor[]>data.json());
    }
}