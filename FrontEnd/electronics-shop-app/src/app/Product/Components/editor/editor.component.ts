import { Component, OnInit } from '@angular/core';
import { NotificationService } from 'src/app/Shared/Services/notification.service';
import { Location } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { EditorMode } from 'src/app/Shared/Models/editor-mode.enum';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Product } from '../../Models/product';
import { ProductService } from '../../Services/product.service';
import { Category } from 'src/app/Category/Models/category';
import { CategoryService } from 'src/app/Category/Services/category.service';

@Component({
  selector: 'app-editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss']
})
export class EditorComponent implements OnInit {


  editorForm: FormGroup;
  editorMode: EditorMode = EditorMode.add;
  editorModeEnum = EditorMode;
  itemModel: Product = new Product();
  isProccessing: boolean;
  id: number;
  filterSettings:any;
  categories: Category[];


  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private categoryService: CategoryService,
    private notificationService: NotificationService,
    private location: Location,
  ) { }

  ngOnInit() {
    this.buildForm();
    this.getCategoriesLookups();
    this.extractRouteParams();
  }


  buildForm(): void {
    this.editorForm = this.fb.group({
      name: [null, [Validators.required]],
      price: [0, [Validators.required]],
      discount: [0, [Validators.required]],
      twoPiecesDiscount: [0, [Validators.required]],
      count: [0, [Validators.required]],
      description: [null],
      categoryId: [null, [Validators.required]]
    });
  }

  bindModelToForm(): void {
    if (this.itemModel) {
      this.editorForm.patchValue({
        id: this.itemModel.id,
        name: this.itemModel.name,
        price: this.itemModel.price,
        discount: this.itemModel.discount,
        twoPiecesDiscount: this.itemModel.twoPiecesDiscount,
        count: this.itemModel.count,
        description: this.itemModel.description,
        categoryId: this.itemModel.categoryId,
      });
    }
  }

  getCategoriesLookups(){
    this.categoryService.getAllCategories(0,100)
    .subscribe(result=>{
      this.categories = result.collection;
    });
  }

  extractRouteParams(): void {
    let editId = +this.route.snapshot.params['editId'];
    let detailId = +this.route.snapshot.params['detailId'];

    if (editId) {
      this.editorMode = EditorMode.edit
      this.id = editId;
    }
    else if (detailId) {
      this.editorMode = EditorMode.detail;
      this.id = detailId;
    }
    else {
      this.editorMode = EditorMode.add;
    }

    if (this.id) {
      this.productService.getProduct(this.id)
        .subscribe(res => {
          this.itemModel = res;
          this.bindModelToForm();
        },
          (error) => {
            this.notificationService.showError("error");
          })
    }
  }


  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  collectModelFromForm(): void {
    this.itemModel = this.editorForm.value;
    if(this.id){
      this.itemModel.id = this.id;
    }
  }

  save(): void {
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.productService.addProduct(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("Product added Successfully");
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;               
                console.log(error);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.productService.updateProduct(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("Product updated successfully");
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;
                console.log(error);
              });
        }
      }
      else {
        this.isProccessing = false;
        this.notificationService.showError("error");
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

  categoryValueChanged(event){
    
  }

}
