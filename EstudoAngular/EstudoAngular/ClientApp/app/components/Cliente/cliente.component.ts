import { Component, OnInit, OnDestroy } from '@angular/core';
import { ClienteService } from '../../Services/cliente.service';
import { ICliente } from '../../Models/cliente.interface';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';


@Component({
    selector: 'cliente',
    templateUrl: './cliente.component.html'
})
export class ClienteComponent implements OnInit {

    //cliente
    cliente: ICliente = <ICliente>{};
    clientes: ICliente[] = [];

    //variaveis de formulario
    formLabel: string;
    isEditMode: boolean;
    form: FormGroup;

    constructor(private _clienteService: ClienteService, private _formBuilder: FormBuilder) {
        this.form = _formBuilder.group({
            "nome": ["", Validators.required],
            "endereco": ["", Validators.required],
            "telefone": ["", Validators.required],
            "email": ["", Validators.required],
        });
        this.formLabel = "Adicionar Cliente";
        this.isEditMode = false;
    }

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

    onSubmit() {
        this.cliente.nome = this.form.controls["nome"].value;
        this.cliente.endereco = this.form.controls["endereco"].value;
        this.cliente.telefone = this.form.controls["telefone"].value;
        this.cliente.email = this.form.controls["email"].value;

        //incluir 

        if (this.isEditMode) {
            this._clienteService.editCliente(this.cliente)
                .subscribe(response => {
                    this.getClientes();
                    this.form.reset();
                });
        }
        else {
            this._clienteService.addCliente(this.cliente)
                .subscribe(response => {
                    this.getClientes();
                    this.form.reset();
                });
        }
    };

    cancel() {
        this.formLabel = "Adicionar cliente";
        this.isEditMode = false;
        this.cliente = <ICliente>{};
        //limpar campos do formulario
        this.form.get("nome")!.setValue('');
        this.form.get("telefone")!.setValue('');
        this.form.get("endereco")!.setValue('');
        this.form.get("email")!.setValue('');
    };

    edit(clienteForm: ICliente) {
        this.formLabel = "Editar cliente";
        this.isEditMode = true;
        this.cliente = clienteForm;
        //preencher campos do formulario
        this.form.get("nome")!.setValue(clienteForm.nome);
        this.form.get("telefone")!.setValue(clienteForm.telefone);
        this.form.get("endereco")!.setValue(clienteForm.endereco);
        this.form.get("email")!.setValue(clienteForm.email);
    };

    delete(clienteForm: ICliente) {
        if (confirm("Deseja excluir esse cliente?")) {
            this._clienteService.deleteCliente(clienteForm.id)
                .subscribe(response => {
                    this.getClientes();
                    this.form.reset();
                });
        }
    };
}