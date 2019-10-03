import { Injectable } from '@angular/core';
import { Http, Response } from "@angular/http";
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";
import { ICategoria } from "../Models/categoria.interface";

@Injectable()
export class CategoriaService {
    constructor(private http: Http) { }

    getCategorias() {
        return this.http.get("/api/categoria").map(data => <ICategoria[]>data.json());
    }

    addCategoria(categoria: ICategoria) {
        return this.http.post("/api/categoria", categoria);
    }

    editCategoria(categoria: ICategoria) {
        return this.http.put(`/api/categoria/${categoria.categoriaId}`, categoria);
    }

    deleteCategoria(categoriaId: number) {
        return this.http.delete(`/api/categoria/${categoriaId}`);
    }
}