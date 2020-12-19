import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CategoryService } from '../../Services/category.service';
import { Router, ActivatedRoute } from '@angular/router';
import { EditorMode } from 'src/app/Shared/Models/editor-mode.enum';
import { Category } from '../../Models/category';
import { NotificationService } from 'src/app/Shared/Services/notification.service';
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
  itemModel: Category = new Category();
  isProccessing: boolean;
  id: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService,
    private notificationService: NotificationService,
    private location: Location,
  ) { }

  ngOnInit() {
    this.buildForm();
    this.extractRouteParams();

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
      this.categoryService.getCategory(this.id)
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
      name: [null, [Validators.required]]
    });
  }

  bindModelToForm(): void {
    if (this.itemModel) {
      this.editorForm.patchValue({
        name: this.itemModel.name
      });
    }
  }

  canEdit(): boolean {
    return this.editorMode != EditorMode.detail;
  }

  collectModelFromForm(): void {
    this.itemModel.name = this.editorForm.controls["name"].value;
  }

  gotoList() {
    let url = [`/category/list`];
    this.router.navigate(url);
  }


  save(): void {
    if (this.canEdit()) {
      this.isProccessing = true;

      if (this.editorForm.valid) {
        if (this.editorMode == EditorMode.add) {
          this.collectModelFromForm();
          this.categoryService.addCategory(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("Category added Successfully");
              this.gotoList();
            },
              (error) => {
                this.isProccessing = false;               
                console.log(error);
              });
        }
        else if (this.editorMode == EditorMode.edit) {
          this.collectModelFromForm();
          this.categoryService.updateCategory(this.itemModel)
            .subscribe(res => {
              this.notificationService.showSuccess("Category updated successfully");
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

  goToBack() {
    this.location.back();
  }


}
