import { Component, OnInit, OnDestroy } from '@angular/core';
import { AppService } from "../../Services/app.service";
import { ICategoria } from "../../Models/categoria.interface";
import { IFornecedor } from "../../Models/fornecedor.interface";
import { IProduto } from "../../Models/produto.interface";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-produto',
    templateUrl: './produto.component.html',
})
export class ProdutoComponent implements OnInit {

    categorias: ICategoria[] = [];
    produtos: IProduto[] = [];
    fornecedores: IFornecedor[] = [];
    formLabel: string;
    isEditMode = false;
    form: FormGroup;
    produto: IProduto = <IProduto>{};

    constructor(private produtoService: AppService, private formBuilder: FormBuilder) {
        this.form = formBuilder.group({
            "nome": ["", [Validators.pattern('[a-zA-Z][a-zA-Z ]+$'), Validators.required]],
            "quantidade": ["", [Validators.required, Validators.pattern("^[0-9]*[1-9][0-9]*$")]],
            "preco": ["", [Validators.required, Validators.pattern("[0-9]+(\.[0-9][0-9]?)?"), Validators.minLength(0)]],
            "categoria": ["", Validators.required],
            "fornecedor": ["", Validators.required]
        });

        this.formLabel = "Adicionar Produto";
    }

    ngOnInit() {
        this.getProdutos();

        this.produtoService.getCategorias().subscribe(categorias => {
            this.categorias = categorias;
        });

        this.produtoService.getFornecedores().subscribe(fornecedores => {
            this.fornecedores = fornecedores;
        });
    }

    onSubmit() {
        this.produto.nome = this.form.controls['nome'].value;
        this.produto.quantidade = this.form.controls['quantidade'].value;
        this.produto.preco = this.form.controls['preco'].value;
        this.produto.fornecedorId = this.form.controls['fornecedor'].value;
        this.produto.categoriaId = this.form.controls['categoria'].value;
        if (this.isEditMode) {
            this.produtoService.editProduto(this.produto).subscribe(response => {
                this.getProdutos();
                this.form.reset();
            });
        } else {
            this.produtoService.addProduto(this.produto).subscribe(response => {
                this.getProdutos();
                this.form.reset();
            });
        }
    }

    cancel() {
        this.formLabel = "Adicionar Produto";
        this.isEditMode = false;
        this.produto = <IProduto>{};
        this.form.get("nome").setValue('');
        this.form.get("quantidade").setValue('');
        this.form.get('preco').setValue('');
        this.form.get('fornecedor').setValue('');
        this.form.get('categoria').setValue('');
    }

    edit(produto: IProduto) {
        this.formLabel = "Editar Produto";
        this.isEditMode = true;
        this.produto = produto;
        this.form.get("nome").setValue(produto.nome);
        this.form.get("quantidade").setValue(produto.quantidade);
        this.form.get('preco').setValue(produto.preco);
        this.form.get('fornecedor').setValue(produto.fornecedorId);
        this.form.get('categoria').setValue(produto.categoriaId);
    }

    delete(produto: IProduto) {
        if (confirm("Deseja realmente deletar este produto ?")) {
            this.produtoService.deleteProduto(produto.produtoId).subscribe(response => {
                this.getProdutos();
                this.form.reset();
            });
        }
    }

    private getProdutos() {
        this.produtoService.getProdutos().subscribe(
            data => this.produtos = data,
            error => alert(error),
            () => console.log("Finished getProdutos-> web api")
        );
    }

    //private getProdutos() {
    //     this.produtoService.getProdutos().subscribe(produtos => {
    //         this.produtos = produtos;
    //     });
    //}
}