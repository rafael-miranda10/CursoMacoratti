import { Injectable } from '@angular/core';
import { Http, Response } from "@angular/http";
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";
import { IProduto } from "../Models/produto.interface";
import { ICategoria } from "../Models/categoria.interface";
import { IFornecedor } from "../Models/fornecedor.interface";

@Injectable()
export class AppService {
    constructor(private http: Http){ }

    getProdutos() {
        return this.http.get("/api/produto").map(data => <IProduto[]>data.json());
    }

    addProduto(produto: IProduto) {
        return this.http.post("/api/produto", produto);
    }

    editProduto(produto: IProduto) {
        return this.http.put(`/api/produto/${produto.produtoId}`, produto);
    }

    deleteProduto(clienteId: number) {
        return this.http.delete(`/api/produto/${clienteId}`);
    }

    getCategorias() {
        return this.http.get("/api/categoria").map(data => <ICategoria[]>data.json());
    }

    getFornecedores() {
        return this.http.get("/api/fornecedor").map(data => <IFornecedor[]>data.json());
    }

}