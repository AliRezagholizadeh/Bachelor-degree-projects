/****************************************************************************
** Meta object code from reading C++ file 'mainwindow2.h'
**
** Created: Tue May 24 15:38:39 2011
**      by: The Qt Meta Object Compiler version 62 (Qt 4.7.0)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include "../cal2/mainwindow2.h"
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'mainwindow2.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 62
#error "This file was generated using the moc from 4.7.0. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
static const uint qt_meta_data_MainWindow2[] = {

 // content:
       5,       // revision
       0,       // classname
       0,    0, // classinfo
      21,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: signature, parameters, type, tag, flags
      13,   12,   12,   12, 0x08,
      40,   12,   12,   12, 0x08,
      67,   12,   12,   12, 0x08,
      94,   12,   12,   12, 0x08,
     121,   12,   12,   12, 0x08,
     148,   12,   12,   12, 0x08,
     175,   12,   12,   12, 0x08,
     202,   12,   12,   12, 0x08,
     229,   12,   12,   12, 0x08,
     256,   12,   12,   12, 0x08,
     283,   12,   12,   12, 0x08,
     310,   12,   12,   12, 0x08,
     337,   12,   12,   12, 0x08,
     363,   12,   12,   12, 0x08,
     389,   12,   12,   12, 0x08,
     415,   12,   12,   12, 0x08,
     441,   12,   12,   12, 0x08,
     467,   12,   12,   12, 0x08,
     493,   12,   12,   12, 0x08,
     519,   12,   12,   12, 0x08,
     545,   12,   12,   12, 0x08,

       0        // eod
};

static const char qt_meta_stringdata_MainWindow2[] = {
    "MainWindow2\0\0on_pushButton_21_clicked()\0"
    "on_pushButton_20_clicked()\0"
    "on_pushButton_19_clicked()\0"
    "on_pushButton_17_clicked()\0"
    "on_pushButton_16_clicked()\0"
    "on_pushButton_11_clicked()\0"
    "on_pushButton_18_clicked()\0"
    "on_pushButton_15_clicked()\0"
    "on_pushButton_14_clicked()\0"
    "on_pushButton_13_clicked()\0"
    "on_pushButton_12_clicked()\0"
    "on_pushButton_10_clicked()\0"
    "on_pushButton_9_clicked()\0"
    "on_pushButton_8_clicked()\0"
    "on_pushButton_7_clicked()\0"
    "on_pushButton_6_clicked()\0"
    "on_pushButton_5_clicked()\0"
    "on_pushButton_4_clicked()\0"
    "on_pushButton_3_clicked()\0"
    "on_pushButton_2_clicked()\0"
    "on_pushButton_clicked()\0"
};

const QMetaObject MainWindow2::staticMetaObject = {
    { &QMainWindow::staticMetaObject, qt_meta_stringdata_MainWindow2,
      qt_meta_data_MainWindow2, 0 }
};

#ifdef Q_NO_DATA_RELOCATION
const QMetaObject &MainWindow2::getStaticMetaObject() { return staticMetaObject; }
#endif //Q_NO_DATA_RELOCATION

const QMetaObject *MainWindow2::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->metaObject : &staticMetaObject;
}

void *MainWindow2::qt_metacast(const char *_clname)
{
    if (!_clname) return 0;
    if (!strcmp(_clname, qt_meta_stringdata_MainWindow2))
        return static_cast<void*>(const_cast< MainWindow2*>(this));
    return QMainWindow::qt_metacast(_clname);
}

int MainWindow2::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QMainWindow::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        switch (_id) {
        case 0: on_pushButton_21_clicked(); break;
        case 1: on_pushButton_20_clicked(); break;
        case 2: on_pushButton_19_clicked(); break;
        case 3: on_pushButton_17_clicked(); break;
        case 4: on_pushButton_16_clicked(); break;
        case 5: on_pushButton_11_clicked(); break;
        case 6: on_pushButton_18_clicked(); break;
        case 7: on_pushButton_15_clicked(); break;
        case 8: on_pushButton_14_clicked(); break;
        case 9: on_pushButton_13_clicked(); break;
        case 10: on_pushButton_12_clicked(); break;
        case 11: on_pushButton_10_clicked(); break;
        case 12: on_pushButton_9_clicked(); break;
        case 13: on_pushButton_8_clicked(); break;
        case 14: on_pushButton_7_clicked(); break;
        case 15: on_pushButton_6_clicked(); break;
        case 16: on_pushButton_5_clicked(); break;
        case 17: on_pushButton_4_clicked(); break;
        case 18: on_pushButton_3_clicked(); break;
        case 19: on_pushButton_2_clicked(); break;
        case 20: on_pushButton_clicked(); break;
        default: ;
        }
        _id -= 21;
    }
    return _id;
}
QT_END_MOC_NAMESPACE
