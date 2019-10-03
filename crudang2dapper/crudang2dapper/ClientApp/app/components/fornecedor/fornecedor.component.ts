import { Component, OnInit, OnDestroy } from '@angular/core';
import { FornecedorService } from "../../Services/fornecedor.service";
import { IFornecedor } from "../../Models/fornecedor.interface";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-fornecedor',
    templateUrl: './fornecedor.component.html',
})
export class FornecedorComponent implements OnInit {

    fornecedores: IFornecedor[] = [];
    formLabel: string;
    isEditMode = false;
    form: FormGroup;
    fornecedor: IFornecedor = <IFornecedor>{};

    constructor(private fornecedorService: FornecedorService, private formBuilder: FormBuilder) {
        this.form = formBuilder.group({
            "nome": ["", [Validators.minLength(5),Validators.pattern('[a-zA-Z][a-zA-Z ]+$'), Validators.required]],
            "endereco": ["", Validators.required],
            "contatoNome": ["", [Validators.pattern('[a-zA-Z][a-zA-Z ]+$'),Validators.required]],
            "email": ["", [Validators.required, Validators.email]]
        });

        this.formLabel = "Adicionar Fornecedor";
    }

    ngOnInit() {
        this.getFornecedores();
    }

    onSubmit() {

        this.fornecedor.nome = this.form.controls['nome'].value;
        this.fornecedor.endereco = this.form.controls['endereco'].value;
        this.fornecedor.contatoNome = this.form.controls['contatoNome'].value;
        this.fornecedor.email = this.form.controls['email'].value;
        if (this.isEditMode) {
            this.fornecedorService.editFornecedor(this.fornecedor).subscribe(response => {
                this.getFornecedores();
                this.form.reset();
            });
        } else {
            this.fornecedorService.addFornecedor(this.fornecedor).subscribe(response => {
                this.getFornecedores();
                this.form.reset();
            });
        }
    }

    cancel() {
        this.formLabel = "Adicionar Fornecedor";
        this.isEditMode = false;
        this.fornecedor = <IFornecedor>{};
        this.form.get("nome").setValue('');
        this.form.get("endereco").setValue('');
        this.form.get('contatoNome').setValue('');
        this.form.get('email').setValue('');
    }

    edit(fornecedor: IFornecedor) {
        this.formLabel = "Editar Fornecedor";
        this.isEditMode = true;
        this.fornecedor = fornecedor;
        this.form.get("nome").setValue(fornecedor.nome);
        this.form.get("endereco").setValue(fornecedor.endereco);
        this.form.get('contatoNome').setValue(fornecedor.contatoNome);
        this.form.get('email').setValue(fornecedor.email);
    }

    delete(fornecedor: IFornecedor) {
        if (confirm("Deseja realmente deletar este fornecedor ?")) {
            this.fornecedorService.deleteFornecedor(fornecedor.fornecedorId).subscribe(response => {
                this.getFornecedores();
                this.form.reset();
            });
        }
    }

    private getFornecedores() {
        this.fornecedorService.getFornecedores().subscribe(
            data => this.fornecedores = data,
            error => alert(error),
            () => console.log("Finished GetFornecedores -> web api")
        );
    }
}