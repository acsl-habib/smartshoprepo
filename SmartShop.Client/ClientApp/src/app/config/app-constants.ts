export class AppConstants {
  static apiUrl = "http://localhost:5000";
  static webUrl = "http://localhost:5001";
  static appName = "Shop Smart";
  static navItems = [
    {
      label: 'Home',
      icon: 'home',
      link: '/home'
    },
    {
      label: "Item setup",
      icon: 'perm_data_setting',
      items: [
        {
          "label": "Brands",
          "icon": "perm_data_setting",
          "link": '/brands'
        },
        {
          "label": "Categories",
          "icon": "category",
          "link": '/categories'
        },
        {
          "label": "Subcategories",
          "icon": "subtitles",
          "link": '/subcategories'
        },
        {
          "label": "Configuration labels",
          "icon": 'tune',
          "link": '/product-config'
        },
        {
          label: "Shipping",
          icon: "local_shipping",
          link: "/shipping"
        },
        {
          label: 'Payment modes',
          icon: 'payments',
          link: '/payments'
        }
      ]
    },
    {
      label: 'Products',
      icon: 'category',
      items: [
        {
          label: 'Campaigns',
          icon: 'campaign',
          link: '/campaigns'
        },
        {
          label: 'Products',
          icon: 'inventory_2',
          link: '/products'
        }
        
      ]
    },
    {
      label: "Customers",
      icon: "groups",
      items: [
        {
          label: "Customer list",
          icon: "format_list_bulleted",
          link: "/customers"
        }

      ]
    },
    {
      "label": "Orders",
      "icon": "shopping_cart_checkout",
      "link": "/orders"
    },
    {
      "label": "Users",
      "icon": "group",
      "items": [
        {
          "label": "User and Roles",
          "icon": "manage_accounts",
          "link":"/users"
        }
      ]
    }
  ];
}
