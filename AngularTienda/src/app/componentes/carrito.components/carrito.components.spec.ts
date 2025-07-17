import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarritoComponents } from './carrito.components';

describe('CarritoComponents', () => {
  let component: CarritoComponents;
  let fixture: ComponentFixture<CarritoComponents>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarritoComponents]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarritoComponents);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
