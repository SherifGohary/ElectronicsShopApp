import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/Product/Models/product';
import { ProductService } from 'src/app/Product/Services/product.service';
import { EditorMode } from 'src/app/Shared/Models/editor-mode.enum';
import { NotificationService } from 'src/app/Shared/Services/notification.service';
import { Order } from '../../Models/order';
import { OrderService } from '../../Services/order.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit {


  editorForm: FormGroup;
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  itemModel: Order = new Order();
  product: Product = new Product();
  isProccessing: boolean;
  id: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService,
    private productService: ProductService,
    private notificationService: NotificationService,
    private location: Location,
  ) { }

  ngOnInit() {
    this.buildForm();
    this.extractRouteParams();
  }


  getProduct(productId: number){
    this.productService.getProduct(productId).subscribe(result=>{
      this.product = result;
    });
  }

  extractRouteParams(): void {
    // let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];
    let productId = +this.route.snapshot.params['productId'];

    // if (editId) {
    //   this.editorMode = EditorMode.edit
    //   this.id = editId;
    // }
    // else 
    if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else if(productId){
      this.getProduct(productId);
      this.itemModel.product = this.product;
    }

    if (this.id) {
      this.orderService.getOrder(this.id)
        .subscribe(res => {
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showError("error");
          })
    }
  }


  buildForm(): void {
    this.editorForm = this.fb.group({
      numberOfItems: [null, [Validators.required]]
    });
  }

  bindModelToForm(): void {
    if (this.itemModel) {
      this.editorForm.patchValue({
        numberOfItems: this.itemModel.numberOfItems
      });
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  numberOfItemsChange(event){
    console.log(event);
  }

  collectModelFromForm(): void {
    this.itemModel.numberOfItems = this.editorForm.controls["numberOfItems"].value;
  }

  save(): void {
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.orderService.addOrder(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("Order added Successfully");
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;               
                console.log(error);
              });
        }
      }
    }
  }

  gotoList() {
    let url = [`/product/list`];
    this.router.navigate(url);
  }

  goToBack() {
    this.location.back();
  }

}
