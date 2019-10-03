import { Component, OnInit, OnDestroy } from '@angular/core';
import { CategoriaService } from "../../Services/categoria.service";
import { ICategoria } from "../../Models/categoria.interface";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-categoria',
    templateUrl: './categoria.component.html',
})
export class CategoriaComponent implements OnInit {

    categorias: ICategoria[] = [];
    formLabel: string;
    isEditMode = false;
    form: FormGroup;
    categoria: ICategoria = <ICategoria>{};

    constructor(private categoriaService: CategoriaService, private formBuilder: FormBuilder) {
        this.form = formBuilder.group({
            "categoriaNome": ["",[
                Validators.maxLength(50),
                Validators.pattern('[a-zA-Z]*'),
                Validators.required]],
        });

        this.formLabel = "Adicionar Categoria";
    }

    ngOnInit() {
        this.getCategorias();
    }

    onSubmit() {
        this.categoria.categoriaNome = this.form.controls['categoriaNome'].value;
        if (this.isEditMode) {
            this.categoriaService.editCategoria(this.categoria).subscribe(response => {
                this.getCategorias();
                this.form.reset();
            });
        } else {
            this.categoriaService.addCategoria(this.categoria).subscribe(response => {
                this.getCategorias();
                this.form.reset();
            });
        }
    }

    cancel() {
        this.formLabel = "Adicionar Categoria";
        this.isEditMode = false;
        this.categoria = <ICategoria>{};
        this.form.get("categoriaNome").setValue('');
    }

    edit(categoria: ICategoria) {
        this.formLabel = "Editar Categoria";
        this.isEditMode = true;
        this.categoria = categoria;
        this.form.get("categoriaNome").setValue(categoria.categoriaNome);
    }

    delete(categoria: ICategoria) {
        if (confirm("Deseja realmente deletar esta categoria ?")) {
            this.categoriaService.deleteCategoria(categoria.categoriaId).subscribe(response => {
                this.getCategorias();
                this.form.reset();
            });
        }
    }

    private getCategorias() {
        this.categoriaService.getCategorias().subscribe(
            data => this.categorias = data,
            error => alert(error),
            () => console.log("Finished GetCategorias -> web api")
        );
    }
}